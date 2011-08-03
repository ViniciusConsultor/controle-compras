// JScript File
Mascaras = {
IsIE: navigator.appName.toLowerCase().indexOf('microsoft')!=-1,
AZ: /[A-Z]/i,
Acentos: /[À-ÿ]/i,
Num: /[0-9]/,
NumNegativo: /[\-0-9]/,
carregar: function(parte){
 var Tags = ['input','textarea'];
 if (typeof parte == "undefined") parte = document;
 for(var z=0;z<Tags.length;z++){
  Inputs=parte.getElementsByTagName(Tags[z]);
  for(var i=0;i<Inputs.length;i++)
   if(('button,image,hidden,submit,reset').indexOf(Inputs[i].type.toLowerCase())==-1)
   {
    this.aplicar(Inputs[i]);
   }
 }
},
aplicar: function(campo){
 tipo = campo.getAttribute('tipo');
 if (!tipo || campo.type == "select-one") return;
 orientacao = campo.getAttribute('orientacao');
 mascara = campo.getAttribute('mascara');
 if (tipo.toLowerCase() == "decimal"){
  orientacao = "esquerda";
  casasdecimais = campo.getAttribute('casasdecimais');
  tamanho = campo.getAttribute('maxLength');
  if (!tamanho || tamanho > 50)
   tamanho = 10;
  if (!casasdecimais)
   casasdecimais = 2;
  campo.setAttribute("mascara", this.geraMascaraDecimal(tamanho, casasdecimais));
  campo.setAttribute("tipo", "numerico");
  campo.setAttribute("orientacao", orientacao);
 }
 if (orientacao && orientacao.toLowerCase() == "esquerda") campo.style.textAlign = "right";
 if (mascara) campo.setAttribute("maxLength", mascara.length);
 if (tipo){
  campo.onkeypress = function(e){ return Mascaras.onkeypress(event); };
  campo.onkeyup = function(e){ Mascaras.onkeyup(event, campo); };
  campo.onpaste = function(e){ return Mascaras.onpaste(event, campo)};
 }
 campo.setAttribute("snegativo", ((campo.value).substr(0,1) == "-" ? "s" : "n"));
},
onkeypress: function(e){
 
 KeyCode = this.IsIE ? event.keyCode : e.which;
 campo =  this.IsIE ? event.srcElement : e.target;
 readonly = campo.getAttribute('readonly');
 tipo = campo.getAttribute('tipo').toLowerCase();
 negativo = "true" == campo.getAttribute('negativo');
 expressao = campo.getAttribute('expressao');

 if (readonly) return;
 
 if (KeyCode == 0) return true;
 
 Char = String.fromCharCode(KeyCode);
 valor = campo.value;
 mascara = campo.getAttribute('mascara');
 
 maxlength = campo.getAttribute('maxlength');
 
 if("textarea" == campo.tagName)
 {
    if(maxlength <= campo.innerText.length)
    {
        return false;
    }
 }
 else
 {
    if(maxlength <= campo.value.length)
    {
        return false;
    }
 }
 
 pt = campo.getAttribute('pt');
 selecao = this.selecao(campo);

 if (selecao.length > 0 && KeyCode != 0){
  
  if (KeyCode != 8){
  
  if(negativo && KeyCode == 45){    
   snegativo = campo.getAttribute('snegativo');
   snegativo = (snegativo == "s" ? "n" : "s");   
   campo.setAttribute("snegativo", snegativo);
  }else{  
   valor += Char;
   
   if (tipo == "numerico" && Char.search(this.Num) == -1) return false;
   if (KeyCode != 32 && tipo == "caracter" && Char.search(this.AZ) == -1 && Char.search(this.Acentos) == -1) return false;
  }
 }
  campo.value = ""; 
  return true;
 }
 
 if (KeyCode != 8){  
  if(negativo && KeyCode == 45){  
   snegativo = campo.getAttribute('snegativo');
   snegativo = (snegativo == "s" ? "n" : "s");  
   campo.setAttribute("snegativo", snegativo);
  }else{   
   valor += Char;   
   if (tipo == "numerico" && Char.search(this.Num) == -1) return false;
   if (KeyCode != 32 && tipo == "caracter" && Char.search(this.AZ) == -1 && Char.search(this.Acentos) == -1) return false;
  }
 }
 
 if (mascara){
  this.aplicarMascara(campo, valor);
  return false;
 }
 
 if(expressao &&
 "texto" == tipo.toLowerCase())
 {
    return this.testarExpressao(expressao, Char);
 }
 
 return true;
},
onkeyup: function(e, campo){
 if(campo)
 {
   valor = campo.value;
   tipo = campo.getAttribute("tipo");
   negativo = "true" == campo.getAttribute('negativo');
   var expressao = campo.getAttribute("expressao");
 
   if(tipo && valor)
	{
		switch(tipo.toLowerCase())
		{
			case "numerico":
				if(null == valor.match((negativo ? this.NumNegativo : this.Num)))
				{
					campo.value = "";
					return false;
				}
				break;
			case "decimal":
				if(null == valor.match(this.Num))
				{
					campo.value = "";
					return false;
				}
				break;
			case "texto":
			    if(expressao)
			    {
			        var re = new RegExp(expressao,"i");
			        if(null == valor.match(re))
				    {
					    campo.value = "";
					    return false;
				    }
			    }
			    break;
		}
	}
 }
 KeyCode = this.IsIE ? event.keyCode : e.which;
 if (KeyCode != 9 && KeyCode != 16 && KeyCode != 109){
  valor = campo.value;
  if (KeyCode == 8 && !this.IsIE) valor = valor.substr(0,valor.length-1);
  this.aplicarMascara(campo, valor);
 }
},
aplicarMascara: function(campo, valor){
 mascara = campo.getAttribute('mascara');
 if (!mascara) return;
 negativo = campo.getAttribute('negativo');
 snegativo = campo.getAttribute('snegativo');
 
 if (negativo && valor.substr(0,1) == "-") 
  valor = valor.substr(1,valor.length-1);
  
 orientacao = campo.getAttribute('orientacao');
 var i = 0;
 for(i=0;i<mascara.length;i++){
  caracter = mascara.substr(i,1);
  if (caracter != "#") valor = valor.replace(caracter, "");
 }
 retorno = "";
 if (orientacao != "esquerda"){
  contador = 0;
  for(i=0;i<mascara.length;i++){
   caracter = mascara.substr(i,1);
   if (caracter == "#"){
    retorno += valor.substr(contador,1);
    contador++;
   }else
    retorno += caracter;
   if(contador >= valor.length) break;
  }
 }else{
  contador = valor.length-1;
  for(i=mascara.length-1;i>=0;i--){
   if(contador < 0) break;
   caracter = mascara.substr(i,1);
   if (caracter == "#"){
    retorno = valor.substr(contador,1) + retorno;
    contador--;
   }else
    retorno = caracter + retorno;
  }
 }
 
 if (negativo && snegativo == "s" &&
 "" != retorno)
 {
  retorno = "-" + retorno;
  }
  else if(45 != event.keyCode)
{
    campo.setAttribute("snegativo", false);
}
 campo.value = retorno;
},
geraMascaraDecimal: function(tam, decimais){
 var retorno = ""; var contador = 0; var i = 0;
 decimais = parseInt(decimais);
 for (i=0;i<(tam-(decimais+1));i++){
  retorno = "#" + retorno;
  contador++;
  if (contador == 3){
   retorno = "." + retorno;
   contador=0;
  }
 }
 retorno = retorno + ",";
 for (i=0;i<decimais;i++) retorno += "#";
 return retorno;
},
selecao: function(campo){
 if (this.IsIE)
  return document.selection.createRange().text;
 else
  return (campo.value).substr(campo.selectionStart, (campo.selectionEnd - campo.selectionStart));
},
formataValor: function (valor, decimais){
 valor = valor.split('.');
 if (valor.length == 1) valor[1] = "";
 for(var i=valor[1].length;i<decimais;i++)
  valor[1] += "0"; 
 valor[1] = valor[1].substr(0,2);
 return (valor[0] + "." + valor[1]);
},
onpaste: function (e, campo){
   if(window.clipboardData){
       valor = window.clipboardData.getData("Text");
       tipo = campo.getAttribute("tipo");
       var expressao = campo.getAttribute("expressao");
       var i;
       
       switch(tipo.toLowerCase())
       {
            case "numerico":               
               return this.testarRegex(this.Num,valor);
            case "decimal":
               valor = valor.replace(".","").replace(",","");
               return this.testarRegex(this.Num,valor);               
            case "texto":
               if(expressao)
               {
                    return this.testarExpressao(expressao,valor);
               }
               break;
       }
   }
   return true;
},
testarExpressao: function (expressao, valor)
{
    for(var i=0 ; i<valor.length ; i++)
    {
        var Char = valor.charAt(i);
        var re = new RegExp(expressao,"i");
        if(null == Char.match(re))
        {
            return false;
        }
    }
    return true;
},
testarRegex: function (re, valor)
{
    for(var i=0 ; i<valor.length ; i++)
    {
        var Char = valor.charAt(i);
        if(null == Char.match(re))
        {
            return false;
        }
    }
    return true;
}
};


