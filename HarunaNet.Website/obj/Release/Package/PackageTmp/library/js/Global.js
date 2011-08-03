/*************constantes de Expressões Regulares*************/
var reRg = "^[0-9]{2}\.[0-9]{3}\.[0-9]{3}-[0-9]$"
var reCnpj = "^[0-9]{2}\.[0-9]{3}\.[0-9]{3}\\[0-9]{4}-[0-9]{2}|[0-9]{2}[0-9]{3}[0-9]{3}\\[0-9]{4}-[0-9]{2}|[0-9]{2}[0-9]{3}[0-9]{3}[0-9]{4}-[0-9]{2}|[0-9]{2}[0-9]{3}[0-9]{3}[0-9]{4}[0-9]{2}$"
var reCpf = "^[0-9]{3}\.[0-9]{3}\.[0-9]{3}-[0-9]{2}|[0-9]{3}[0-9]{3}[0-9]{3}-[0-9]{2}|[0-9]{3}[0-9]{3}[0-9]{3}[0-9]{2}$"
var reTelefone = "^([(][0-9]{3}[)])?[0-9]{4}|[0-9]{3}-?[0-9]{4}$"
var reHora = "^([0-9]|[01][0-9]|2[0-3])[:][0-5][0-9]$"
var reDate = "^([0]?[1-9]|[12][0-9]|[3][0-1])/([0]?[1-9]|1[012])/[0-9]{2,4}$"
var reDateMesAno = "^([0]?[1-9]|1[012])/[0-9]{2,4}$"
var reEmail = "^[a-zA-Z0-9_.-]+@[a-zA-Z0-9_.-]+\.[a-zA-Z]{2,3}\.([a-zA-Z]{2})?$"
var reAlpha = "^[a-zA-Z]+$"
var reNumeric ="^[0-9]+$"
var reIsNumeric = "^[-+]?[0-9]{1,3}((\.[0-9]{3}|[0-9]{3}){1,9})?(,[0-9]{1,})?$"
var reNumericDecimal = "^[-+]?[0-9]{1,3}((\.[0-9]{3}|[0-9]{3}){1,9})?(,[0-9]{1,})?$"
var reAlphaNumeric = "^[a-zA-Z0-9]+$"
var reAlphaSpacePoint = "^[a-zA-Z .]+$"
var reAlphaNumericSpacePoint = "^[a-zA-Z0-9 .]+$"
var reAlphaNumericSpace = "^[a-zA-Z0-9 -_]+$"
var reAlphaNumericPoint = "^[a-zA-Z0-9.]+$"
var reCep = "^[0-9]+$"
var reSenha = "^[^,.']+$"
var reSite = "^[^' ]+$"
var reTudo = "^[^']+$"
var reTel = "^[^']+$"
var reEndereco = "^[^,']+$"
var reRefComercial = "^[^,;']+$"
//var rgNoSpecial = '/^\s*([.@/\-\\:;\s]*[\w\s*][.@/\-\\:;\s]*)*\s*$/'
/*************fim constantes de Expressões Regulares**********/

/*********************************/
function CPF(source, arguments)
/*********************************/
{	
	var lsCPFAux;
	var liCont;
	var liCont2;
	var liSoma;
	var liDigito;
	var lsControle = arguments.Value.replace('.','').replace('.','').replace('-','');
	//alert (lsControle);
	   
	// Adicionar os zeros a esquerda
	var VintResultado;
	var VintTamCampo = lsControle.length;
	VintResultado = 11 - VintTamCampo;

	if(VintResultado > 0 && lsControle != "")
	{
			for(VintControle = 0; VintControle < VintResultado; VintControle++)
			{
				lsControle = "0" + lsControle;
			}		
	}

	lsCPFAux = lsControle.substring(0, 9);
	liSoma = 0

	if (lsControle == "")
	{
		arguments.IsValid = true;
		return true;
	}
	var car = lsCPFAux.charAt(0);
	var flag = true;
	for (i=1; i< lsCPFAux.length; i++)
    {
		if (car != lsCPFAux.charAt(i))
		{
			flag = false;
			break;
		}
    }
    if (flag == true)
    {
		arguments.IsValid = false;
        return (false);
    }

	var re = /^(\s*)(\d+)(\s*)$/;
	if (re.test(lsControle) == false)
	{  
	arguments.IsValid = false;
	return false;
	}

	for (liCont2 = 1; liCont2 <= 2; liCont2++)
	{
		for (liCont = lsCPFAux.length; liCont >= 1; liCont--)
		{
			liSoma = liSoma + ((lsCPFAux.length + 2 - liCont) *
		(eval(lsCPFAux.substring(liCont-1, liCont))));
		}
		liDigito = 11 - (liSoma % 11);
		if (liDigito >= 10)
		{
			liDigito = 0;
		}

		lsCPFAux = lsCPFAux + liDigito;

		liSoma = 0;
	}

	if (lsControle == lsCPFAux)
	{       
		arguments.IsValid = true;
		return true;
	}
	else
	{		
		arguments.IsValid = false;
		return false;
	}	
	
}  // CPF


/*********************************/
function CNPJ(source, arguments)
/*********************************/
{	
    var lsCGC;
    var lsCGCAux;
    var liCont;
    var liDigito;
    var liSoma;
    var lsControle = arguments.Value.replace('.','').replace('.','').replace('.','').replace('-','').replace('/','');
    //alert (lsControle);

	// Adicionar os zeros a esquerda
	var VintResultado;
	var VintTamCampo = lsControle.length;
	VintResultado = 14 - VintTamCampo;

	if(VintResultado > 0 && lsControle != "")
	{
		for(VintControle = 0; VintControle < VintResultado; VintControle++)
		{
			lsControle = "0" + lsControle;
		}
		arguments.Value = lsControle;
	}

	var car = lsControle.charAt(0);
	var flag = true;
	for (i=1; i< lsControle.length; i++)
    {
		if (car != lsControle.charAt(i))
		{
			flag = false;
			break;
		}
    }
    if (flag == true)
    {
		arguments.IsValid = false;
        return (false);
    }

	if (lsControle == "")
	{  
		arguments.IsValid = true;
		return true;
	}

	var re = /^(\s*)(\d+)(\s*)$/;
	if (re.test(lsControle) == false)
	{
		arguments.IsValid = false;
		return false;
	}

	if(lsControle.length < 12)
	{	  
		arguments.IsValid = false;
		return false;
	}

	lsCGCAux = lsControle.substring(0,12);

	liSoma = 0;

	for (liCont = 2; liCont <= 9; liCont++)
	{
		liSoma = liSoma + (liCont * eval(lsCGCAux.substring(13 - liCont, 14-liCont)));
	}

	for (liCont = 2; liCont <= 5; liCont++)
	{
		liSoma = liSoma + (liCont * eval(lsCGCAux.substring(5 - liCont, 6 - liCont)));
	}

	liDigito = 11 - (liSoma % 11);

	if (liDigito >= 10)
	{
		liDigito = 0;
	}

	lsCGCAux = lsCGCAux + liDigito;

	liSoma = 0;

	for(liCont = 2; liCont <= 9; liCont++)
	{
		liSoma = liSoma + liCont * eval(lsCGCAux.substring(14 - liCont, 15 - liCont));
	}

	for(liCont = 2; liCont <= 6; liCont++)
	{
		liSoma = liSoma + (liCont) * eval(lsCGCAux.substring(6 - liCont, 7 - liCont));
	}

	liDigito = 11 - (liSoma % 11);

	if(liDigito >= 10)
	{
		liDigito = 0;
	}

	lsCGCAux = lsCGCAux + liDigito;

	liSoma = 0;

	if(lsControle == lsCGCAux)
	{	  
		arguments.IsValid = true;
		return true;
	}
	else
	{  
		arguments.IsValid = false;
		return false;
	}
	
 }  // CNPJ
 

/*********************************/
function Arredonda(PstrValor)
/*********************************/
{
	var VstrValor;
	var VarrValor;
	var VintDecimal;
	var VbVerificar;	
	var VstrArredonda;
	var PbSoma1 = false;
	VstrValor = PstrValor;
	VarrValor = VstrValor.split(",");
	
	if(PstrValor == ''){return ''}
	
	if(isNaN(Number(VarrValor[1])) == true)
	{
		VstrArredonda = "00";
	}
	else
	{
		VintDecimal = VarrValor[1];
		if(VintDecimal.length == 1)
		{
			VstrArredonda = VintDecimal + "0";
		}
		else
		{
			if(VintDecimal.length >= 3)
			{
				VstrArredonda = VintDecimal.substring(2,3);
				NArredonda = Number(VstrArredonda);
				if(NArredonda > 5)
				{
					VstrArredonda = VintDecimal.substring(0,2);
					var NArredonda;
					NArredonda = new Number(VstrArredonda);
					NArredonda = NArredonda + 1;
					if(NArredonda == 100)
					{
						PbSoma1 = true;
					}
					VstrArredonda = String(NArredonda);
					if(VstrArredonda.length == 1)
					{
						VstrArredonda = "0" + VstrArredonda;
					}

				}
				else
				{
					VstrArredonda = VintDecimal.substring(0,2);
				}
			}
			else
			{				
				VstrArredonda = VintDecimal.substring(0,2);
			}
		}
	}
	var VstrFinal;
	if(PbSoma1 == true)
	{
		var PintSoma;
		PintSoma = new Number(VarrValor[0]);
		PintSoma = PintSoma + 1;
		VstrArredonda = "00";
		VstrFinal = String(PintSoma) + "," + String(VstrArredonda);
	}
	else
	{
		VstrFinal = String(VarrValor[0]) + "," + String(VstrArredonda);
	}
	
	return VstrFinal;

}  // Arredonda


/*********************************/
function TrocaVirgula(valor)
/*********************************/
{
	var i,ch;
	ch = "";

	// Se está no formato moeda
	if (valor.substring(0,2) == "R$")
	{
		valor = valor.substring(3);

		for (i=0;i < valor.length;i++)
		{
			// retira os pontos do formato moeda
			if (valor.substring(i,i+1) != ".")
				ch = ch + valor.substring(i,i+1);  
		}
		
		valor = ch;
		ch = "";
	}
		
	if (valor.length != 0)
	{
		for (i=0;i < valor.length;i++)
		{
			if (valor.substring(i,i+1) == ",")
				ch = ch + ".";
			else
				ch = ch + valor.substring(i,i+1);   
		}
	}
	
	return ch;
		
}  // TrocaVirgula


/*********************************/
function TrocaPonto(valor)
/*********************************/
{
	var i,ch;
	ch = "";

	if (valor.length != 0)
	for (i=0;i < valor.length;i++){
		if (valor.substring(i,i+1) == ".")
		   ch = ch + ",";
		else
		   ch = ch + valor.substring(i,i+1);   
	}
	
	return ch;

}  // TrocaPonto


/*********************************/
function TravaText(PobjCampo)
/*********************************/
{
	var focou = false;
	for(i=0;i <= document.forms[0].elements.length-1;i++)
	{
		if(document.forms[0].elements[i].name == PobjCampo.name)
		{
			while(i < document.forms[0].elements.length-1)
			{
				i++;
				if(document.forms[0].elements[i].type != "hidden")
				{
					focou = true;
					document.forms[0].elements[i].focus();
					break;
				}
			}
		}
	}
	if(focou == true)
	{
		return true;
	}
	else
	{
		i = 0;
		while(i < document.forms[0].elements.length-1)
		{
			if(document.forms[0].elements[i].type != "hidden")
			{
				document.forms[0].elements[i].focus();
				break;
			}
			i++;
		}
		return true;
	}

}  // TravaText


/*********************************/
function isMoeda(oTxt)
/*********************************/
{
	var re = /^(\s*)(\d+)((,\d{1,2}){0,1})(\s*)$/;
	if (re.test(oTxt.value) == false && oTxt.value != "")
	{
		oTxt.focus();
		//alert("O campo " + oTxt.name + " deve ser monetário.");		
		oTxt.value = "";
		return false;
	}
	
	if(oTxt.value != '')
	{
		oTxt.value = Arredonda(TrocaPonto(oTxt.value));
	}	
	
	return true;

}  // isMoeda


/*********************************/
function ChecarBrowser()
/*********************************/
{
	this.ver = navigator.appVersion;
	this.dom = document.getElementById?1:0;
	this.ie7 = (this.ver.indexOf("MSIE 7")>-1 && this.dom)?1:0;
	this.ie6 = (this.ver.indexOf("MSIE 6")>-1 && this.dom)?1:0;
	this.ie5 = (this.ver.indexOf("MSIE 5")>-1 && this.dom)?1:0;
	this.ie4 = (document.all && !this.dom)?1:0;
	this.ns5 = (this.dom && parseInt(this.ver) >= 5) ?1:0;
	this.ns4 = (document.layers && !this.dom)?1:0;
	this.bw  = (this.ie5 || this.ie4 || this.ns4 || this.ns5);
	
}  // ChecarBrowser


// Variável de controle de tabulação
// mudança de foco por limite de tamanho
var VerifiqueTAB = true;

/*********************************/
function PararTAB() 
/*********************************/
{ 
	VerifiqueTAB = false; 
}  // PararTAB


/*********************************/
function ChecarTAB() 
/*********************************/
{ 
	VerifiqueTAB = true; 
}  // ChecarTAB


/*********************************/
function SaltaCampo(oTxt, tammax)
/*********************************/
{		
	var PobjBr = new ChecarBrowser();
	if(PobjBr.ie5 == 1 || PobjBr.ie4 == 1 || PobjBr.ie6 == 1 || PobjBr.ie7 == 1)
	{
		if ((oTxt.value.length == tammax) && (VerifiqueTAB) ) { 
			var i=0,j=0, indice=-1;
			for (i=0; i<document.forms.length; i++) { 
			for (j=0; j<document.forms[i].elements.length; j++) { 
				VobjElementos = document.forms[i].elements[j].name
				
			    if (document.forms[i].elements[j].name == oTxt.name) { 
				    indice=i;
				    break;
			    } 
			} 
			if (indice != -1) break; 
		} 
		for (i=0; i<=document.forms[indice].elements.length; i++) { 
			if (document.forms[indice].elements[i].name == oTxt.name) { 
				while ( (i < document.forms[indice].elements.length) && 
					(document.forms[indice].elements[(i+1)] != null) &&
					(document.forms[indice].elements[(i+1)].type == "hidden")) { 
					i++;
				}
				if (document.forms[indice].elements[(i+1)] == null) { VerifiqueTAB=false; return; }
				document.forms[indice].elements[(i+1)].focus();
				VerifiqueTAB = false;
				break;
				} 
			} 
		} 
	}
}  // SaltaCampo


/*********************************/
function Trim(obj) 
/*********************************/
{
	ini = 0;
	fim = obj.length;
	for (i = 0;i < fim;i++) {
		if (obj.substr(i,1) == " ") {ini = i + 1}
		else {i = obj.length}
	}
	for (i = fim-1;i > 1;i--) {
		if (obj.substr(i,1) == " ") {fim = i - 1}
		else {i = 0}
	}
	return(obj.substr(ini,fim-ini+1));	
}  // Trim


// Atacha funções aos eventos
document.body.onkeydown = ValidarTipo;
document.body.onkeypress = ValidarTipo;
document.body.onpaste = ValidarTipo;



/*********************************/
function ValidarTipo()
/*********************************/
{
	var element = window.event.srcElement;
	
switch (element.datatype)
	{
		case 'date':
			if (window.event.type=='keypress')
				return(date_onkeypress(element));
			else if(window.event.type=='paste')
			    return (no_onpaste())	
			else
				return(date_onkeydown(element));
			break;
		case 'dateMesAno':
			if (window.event.type=='keypress')
				return(dateMesAno_onkeypress(element));
			else if(window.event.type=='paste')
			    return (no_onpaste())	
			else
				return(dateMesAno_onkeydown(element));
			break;
		case 'time':
			if (window.event.type=='keypress')
				return(time_onkeypress(element));
			else if(window.event.type=='paste')
			    return (no_onpaste())	
			else
				return(time_onkeydown(element));
			break;
		case 'uinteger': // Unsigned Integer
		case 'integer':
		if (window.event.type=='keydown')
				return(integer_onkeydown(element));
			else if (window.event.type=='paste')
				return(integer_onpaste());
			break;
		case 'udouble':
		case 'double':
			if (window.event.type=='keydown')
				return (double_onkeydown(element));
			else if(window.event.type=='paste')
			    return (double_onpaste())	
			break;
	    case 'nospecial':
			if (window.event.type=='keypress')
				return (nospecial_onkeypress(element));
			else if(window.event.type=='paste')
			    return (nospecial_onpaste())
			break;
		case 'cnpj':
			if (window.event.type=='keydown')
				return(cnpj_onkeydown(element));
			else if (window.event.type=='paste')
				return(integer_onpaste());
			break;
	}
}  // ValidarTipo

/**********************************************************/
function nospecial_onkeypress(nospecial)
{    
    var tecla = GetTecla();   
    
    if (TeclaOK(tecla)) return(true);
    
    //           Numeros                 letras maiúsculas             letras minúsculas           backspace         tab                  home/end                espaço
    if((tecla > 47 && tecla < 58) || (tecla > 64 && tecla < 91) || (tecla > 96 && tecla < 123) || (tecla == 8) || (tecla == 9) || (tecla > 2  && tecla < 4) || (tecla == 32))
    {
        return true;
    }
    else
    {
        return false;
    }
}

function nospecial_onpaste()
{
	var Re = new RegExp(reAlphaNumericSpace)
	Re.global = false
	Re.ignoreCase = true
	
	strTexto = window.clipboardData.getData("Text");
	return Re.test(strTexto)
}

function no_onpaste()
{
    return false;
}

function double_onkeydown(double)
{
	double.onblur = double_onblur;
	if (integer_onkeydown(double))
	{
		return true;
	}
	else
	{// Verifica se a tecla eh virgula (",")
		var tecla = GetTecla();
		if ((tecla == 110 || tecla == 188) && (!event.shiftKey))
			return(true);
	}
	return false;
}

function double_onblur()
{
	var double = window.event.srcElement;
	
	if(double.value != '')
	{	
	    if(double.value.indexOf(',') == -1)
	    {
	        double.value = double.value + ",00";
	    }
	    else if(double.value.indexOf(',') < (double.value.length - 2))
	    {
	        double.value = double.value.substr(0,double.value.indexOf(',') + 3);
	    }
	    else if(double.value.indexOf(',') < (double.value.length - 1))
	    {
	        double.value = double.value + "0";
	    }
	}	
	return (true);
}


function double_onpaste()
{
	var Re = new RegExp(reNumericDecimal)
	Re.global = false
	Re.ignoreCase = true
	
	strTexto = window.clipboardData.getData("Text");
	return Re.test(strTexto)
}

/*********************************/
function date_onkeypress(date)
/*********************************/
{
	var tecla = GetTecla();
	if (TeclaOK(tecla)) return(true);
	
	if ( tecla == 47 )  // '/'
	{
		var arrDate = date.value.split("/");
		if (arrDate.length>0)
			if (arrDate[0].length==1 && arrDate[0]!="0")
			{
				arrDate[0] = "0" + arrDate[0];
				date.value = arrDate.join("/") + "/";
			}
		if (arrDate.length>1)
			if (arrDate[1].length==1 && arrDate[1]!="0")
			{
				arrDate[1] = "0" + arrDate[1];
				date.value = arrDate.join("/") + "/";
			}
		return false;
	}
	
	// Verifica tamanho máximo
	date.maxLength=10;
	
	return(isNum(String.fromCharCode(tecla)));
}


/*********************************/
function dateMesAno_onkeypress(date)
/*********************************/
{
	var tecla = GetTecla();
	if (TeclaOK(tecla)) return(true);
	
	if ( tecla == 47 )  // '/'
	{
		var arrDate = date.value.split("/");
		if (arrDate.length>0)
			if (arrDate[0].length==1 && arrDate[0]!="0")
			{
				arrDate[0] = "0" + arrDate[0];
				date.value = arrDate.join("/") + "/";
			}
		/*if (arrDate.length>1)
			if (arrDate[1].length==1 && arrDate[1]!="0")
			{
				arrDate[1] = "0" + arrDate[1];
				date.value = arrDate.join("/") + "/";
			}*/
		return false;
	}
	
	// Verifica tamanho máximo
	date.maxLength=7;
	
	return(isNum(String.fromCharCode(tecla)));
}

/*********************************/
function date_onkeydown(date)
/*********************************/
{
	date.onblur = date_onblur;
	var tecla = GetTecla();
	if (TeclaOK(tecla)) return(true);
	var arrDate = date.value.substr(0,10).split("/");
	//Verifica dia
	if (arrDate.length>0)
		if (arrDate[0].length>1 && (arrDate[0]==0 || arrDate[0]>31))
		{
			date.onblur = null;
			alert("Dia Inválido");
			date.value = "";
			return false;
		}
	//Verifica mês
	if (arrDate.length>1)
		if (arrDate[1].length>1 && (arrDate[1]==0 || arrDate[1]>12))
		{
			date.onblur = null;
			alert("Mês Inválido");
			date.value = arrDate[0] + "/";
			return false;
		}
	//Verifica ano
	if (arrDate.length>2)
		if (arrDate[2].length>3 && (arrDate[2]<1900 || arrDate[2]>2100))
		{
			date.onblur = null;
			alert("Ano Inválido");
			date.value = arrDate[0] + "/" + arrDate[1] + "/";
			return false;
		}
	//Adiciona barra de separação
	if (date.value.length==2 || date.value.length==5)
		date.value += "/";
}

/*********************************/
function dateMesAno_onkeydown(date)
/*********************************/
{
	date.onblur = dateMesAno_onblur;
	var tecla = GetTecla();
	if (TeclaOK(tecla)) return(true);
	var arrDate = date.value.substr(0,7).split("/");
	//Verifica mês
	if (arrDate.length>0)
		if (arrDate[0].length>1 && (arrDate[0]==0 || arrDate[0]>12))
		{
			date.onblur = null;
			alert("Mês Inválido");
			date.value = "";
			return false;
		}
	//Verifica ano
	if (arrDate.length>1)
		if (arrDate[1].length>3 && (arrDate[1]<1900 || arrDate[1]>2100))
		{
			date.onblur = null;
			alert("Ano Inválido");
			date.value = arrDate[0] + "/";
			return false;
		}
	//Adiciona barra de separação
	if (date.value.length==2)
		date.value += "/";
}

/*********************************/
function date_onblur()
/*********************************/
{
	var date = window.event.srcElement;
	var arrDate = date.value.substr(0,10).split("/");
	//Verifica data completa
	if (date.value.length==10)
	{
		var datData = new Date(arrDate[2], arrDate[1]-1, arrDate[0]);
		if (datData.getDate()!=arrDate[0] || datData.getMonth()!=arrDate[1]-1 || datData.getFullYear()!=arrDate[2])
		{
			alert("Data Inválida!");
			date.value = "";
			date.focus();
			return false;
		}
	}
	//Verifica se a data esta completa
	if (arrDate.length<3 && date.value!="")
	{
		alert("Data Inválida!");
		date.value = "";
		date.focus();
		return false;
	}

	date.onblur = null;
}

/*********************************/
function dateMesAno_onblur()
/*********************************/
{
	var date = window.event.srcElement;
	var arrDate = date.value.substr(0,7).split("/");
	//Verifica data completa
	if (date.value.length==7)
	{
		var datData = new Date(arrDate[1], arrDate[0]-1, 1);
		if (datData.getMonth()!=arrDate[0]-1 || datData.getFullYear()!=arrDate[1])
		{
			alert("Data Inválida!");
			date.value = "";
			date.focus();
			return false;
		}
	}
	//Verifica se a data esta completa
	if (arrDate.length<2 && date.value!="")
	{
		alert("Data Inválida!");
		date.value = "";
		date.focus();
		return false;
	}

	date.onblur = null;
}


/*********************************/
function date_onpaste()
/*********************************/
{
    return false;
}

/*********************************/
function dateMesAno_onpaste()
/*********************************/
{
    return false;
}


/*********************************/
function time_onkeypress(time)
/*********************************/
{
	var tecla = GetTecla();
	if (TeclaOK(tecla)) return(true);
	
	if ( tecla == 58 )  // ':'
	{
		var arrTime = time.value.split(":");
		if (arrTime.length>0)
			if (arrTime[0].length==1 && arrTime[0]!="0")
			{
				arrTime[0] = "0" + arrTime[0];
				time.value = arrTime.join(":") + ":";
			}
		if (arrTime.length>1)
			if (arrTime[1].length==1 && arrTime[1]!="0")
			{
				arrTime[1] = "0" + arrTime[1];
				time.value = arrTime.join(":") + ":";
			}
		return false;
	}
	// Verifica tamanho máximo
	time.maxLength=5;
	
	return(isNum(String.fromCharCode(tecla)));
}


/*********************************/
function time_onkeydown(time)
/*********************************/
{
	time.onblur = time_onblur;
	var tecla = GetTecla();
	if (TeclaOK(tecla)) return(true);
	var arrTime = time.value.substr(0,8).split(":");
	//Verifica hora
	if (arrTime.length>0)
	{
		if (arrTime[0].length>1 && arrTime[0]>23)
		{
			time.onblur = null;
			alert("Hora Inválida!");
			time.value = "";
			return false;
		}
	}
	
	//Verifica minuto
	if (arrTime.length>1)
	{
		if (arrTime[1].length>1 && arrTime[1]>59)
		{
			time.onblur = null;
			alert("Minuto Inválido!");
			time.value = arrTime[0] + ":";
			return false;
		}
	}
	
	//Adiciona barra de separação
	if (time.value.length==2)   // || time.value.length==5)
	{
		time.value += ":";
	}
}


/*********************************/
function time_onblur()
/*********************************/
{
	var time = window.event.srcElement;
	var arrTime = time.value.substr(0,10).split(":");
	//Verifica seo horário esta completo
	if (arrTime.length<2 && time.value!="")
	{
		alert("Horário Inválido!");
		time.value = "";
		time.focus();
		return false;
	}
	if ((arrTime[0].length<2 || arrTime[1].length<2) && time.value!="")
	{
		alert("Horário Inválido!");
		time.value = "";
		time.focus();
		return false;
	}
	
	if (arrTime.length ==3 && arrTime[2].length<2)
	{
		alert("Horário Inválido!");
		time.value = "";
		time.focus();
		return false;
	}
	
	if (arrTime.length ==3 && arrTime[2]>59)
	{
		alert("Horário Inválido!");
		time.value = "";
		time.focus();
		return false;
	}
	
	if ((arrTime[0]>24 || arrTime[1]>59) && time.value!="")
	{
		alert("Horário Inválido!");
		time.value = "";
		time.focus();
		return false;
	}
	time.onblur = null;
}


/*********************************/
function math_onkeydown(integer)
/*********************************/
{
	var tecla = GetTecla();
	if (tecla>=96 && tecla<=105)
		tecla -= 48;
	if (((tecla == 193) || (tecla == 189) || (tecla == 32) ) && (! event.shiftKey))
	    return true;
	if (TeclaOK(tecla)) return(true);
	
	return(isNum(String.fromCharCode(tecla)) && (! event.shiftKey));
}  // integer_onkeydown

/*********************************/
function math_onpaste()
/*********************************/
{
//	var Re = new RegExp('^[0-9]+$')
//	Re.global = false
//	Re.ignoreCase = true
//	
//	strTexto = window.clipboardData.getData("Text");
//	return Re.test(strTexto)
    return false;
}  // integer_onpaste

/*********************************/
function cnpj_onkeydown(cnpj)
/*********************************/
{
	cnpj.onblur = cnpj_onblur;
	var tecla = GetTecla();
	if (tecla>=96 && tecla<=105)
		tecla -= 48;
	if (TeclaOK(tecla)) return(true);
	return(isNum(String.fromCharCode(tecla)) && (! event.shiftKey));
}  // cnpj_onkeydown

/*********************************/
function cnpj_onblur()
/*********************************/
{
	var cnpj = window.event.srcElement;

	//Verifica data completa
	if (!validaCNPJ(cnpj))
	{
		alert('CNPJ inválido!');
		cnpj.value = '';
		return false;
	}

	cnpj.onblur = null;
}  // cnpj_onblur

/*********************************/
function integer_onkeydown(integer)
/*********************************/
{
	var tecla = GetTecla();
	if (tecla>=96 && tecla<=105)
		tecla -= 48;
	if (TeclaOK(tecla)) return (true);
    	
	return (isNum(String.fromCharCode(tecla)) && (! event.shiftKey));
}  // integer_onkeydown

/*********************************/
function integer_onpaste()
/*********************************/
{
	var Re = new RegExp(reNumeric)
	Re.global = false
	Re.ignoreCase = true
	
	strTexto = window.clipboardData.getData("Text");
	return Re.test(strTexto)
}  // integer_onpaste

/*********************************/
function cep_onpaste()
/*********************************/
{
	var Re = new RegExp('^[0-9-]+$')
	Re.global = false
	Re.ignoreCase = true
	
	strTexto = window.clipboardData.getData("Text");
	return Re.test(strTexto)
}

/*********************************/
function GetTecla()
/*********************************/
{
	var tecla;
	if(navigator.appName.indexOf("Netscape")!= -1) 
		tecla = event.which; 
	else 
		tecla = event.keyCode; 
	return(tecla);
}

/**********************************/
function GetCaracterAcentuado()
/**********************************/
{
    var tecla = GetTecla();
    
    
    if ((tecla == 225) || (tecla == 233) || (tecla == 237) || (tecla == 243) || (tecla == 250) ||
        (tecla == 193) || (tecla == 201) || (tecla == 205) || (tecla == 211) || (tecla == 218) ||
        (tecla == 226) || (tecla == 234) || (tecla == 238) || (tecla == 244) || (tecla == 251) ||
        (tecla == 194) || (tecla == 202) || (tecla == 206) || (tecla == 212) || (tecla == 219) ||
        (tecla == 195) || (tecla == 213) || (tecla == 227) || (tecla == 245) || tecla == 199)
    {
        return true;
    }
    else
    {
        return false;
    }
}


/*********************************/
function TeclaOK(tecla)
/*********************************/
{
	var BACKSPACE = 8; 
	var TAB = 9;
	var ENTER = 13;
	var DELETE = 46;
	
	// Setas, Home e End
	if (tecla>=35 && tecla<=40)
	{
		return true;
	}

	if ( tecla == ENTER ) 
	{
		window.event.keyCode = TAB;
		return true;
	}
	
	if ( tecla == BACKSPACE ) 
	{
		return true;
	}
	
	if ( tecla == DELETE ) 
	{
		return true;
	}
	
	if ( tecla == TAB )
	{
		return true;
	}
	
	if (event.ctrlKey)
	{
		return true;
	}
	
	return false;
		
}  // TeclaOK


/*********************************/
function isNum(caractere)
/*********************************/
{ 
	var strValidos = "0123456789";
	return ( strValidos.indexOf( caractere ) != -1 );

}  // isNum


/*********************************/
function onEnter(cmdPrincipal)
/****************************************************
Colocar no Form: onkeypress="onEnter('cmdOK');"
****************************************************/
{
	try 
	{
		onEnterTextArea(cmdPrincipal);
	}
	catch(e){ } //não faz nada 		
}


// Browser detect code
/* Esta função deverá ser escrita em todas as páginas com a  */
var focustextarea = false;

/*********************************/
function onEnterTextArea(cmdPrincipal)
/*********************************/
{
	/*****************************************************************************
	Quando for escrever uma textarea, colocar:
	onblur=javascript:focustextarea=false; onfocus=javascript:focustextarea=true; 
	, pois a textarea deve aceitar a quebra de linha
	*******************************************************************************/
	var ie4=document.all;
	var ns4=document.layers;
	var ns6=document.getElementById&&!document.all;

	if (ie4)  //codigo para IE
	{ 
		if (event.keyCode == 13 && (!focustextarea))
		{ 
		// ao pressionar ENTER fora de textarea, realizar a principal atividade do formulário	
			var x = document.getElementById (cmdPrincipal);
			x.click();
		}
	}
	else if (ns4 || ns6) //codigo para netscape
	{
		if (event.which == 13 && (!focustextarea))
		{				
			var x = document.getElementById (cmdPrincipal);
			x.click();
		}		
	}
}

function MM_findObj(n, d) { //v4.0
  var p,i,x;  if(!d) d=document; if((p=n.indexOf("?"))>0&&parent.frames.length) {
    d=parent.frames[n.substring(p+1)].document; n=n.substring(0,p);}
  if(!(x=d[n])&&d.all) x=d.all[n]; for (i=0;!x&&i<d.forms.length;i++) x=d.forms[i][n];
  for(i=0;!x&&d.layers&&i<d.layers.length;i++) x=MM_findObj(n,d.layers[i].document);
  if(!x && document.getElementById) x=document.getElementById(n); return x;
}

function MM_preloadImages() { //v3.0
  var d=document; if(d.images){ if(!d.MM_p) d.MM_p=new Array();
    var i,j=d.MM_p.length,a=MM_preloadImages.arguments; for(i=0; i<a.length; i++)
    if (a[i].indexOf("#")!=0){ d.MM_p[j]=new Image; d.MM_p[j++].src=a[i];}}
}

function MM_swapImage() { //v3.0
  var i,j=0,x,a=MM_swapImage.arguments; document.MM_sr=new Array; for(i=0;i<(a.length-2);i+=3)
   if ((x=MM_findObj(a[i]))!=null){document.MM_sr[j++]=x; if(!x.oSrc) x.oSrc=x.src; x.src=a[i+2];}
}

function MM_swapImgRestore() { //v3.0
  var i,x,a=document.MM_sr; for(i=0;a&&i<a.length&&(x=a[i])&&x.oSrc;i++) x.src=x.oSrc;
}

function MM_showHideLayers() { //v3.0
  var i,p,v,obj,args=MM_showHideLayers.arguments;
  for (i=0; i<(args.length-2); i+=3) if ((obj=MM_findObj(args[i]))!=null) { v=args[i+2];
    if (obj.style) { obj=obj.style; v=(v=='show')?'visible':(v='hide')?'hidden':v; }
    obj.visibility=v; }
}

/***********************************************
Exemplo: 

<asp:TextBox id="TextBox1" runat="server" 
	nomelabel="Matrícula do Item 1" 
	datatype="integer" 
	obrigatorio="True"></asp:TextBox>

Parametros a serem adicionados no campo a ser validado:
+ nomelabel: é o nome a ser escrito na mensagem de erro. 
	Não é obrigatorio, mas se não preenchido, não mudará a mensagem de erro.
	Ex: O campo xxx é obrigatorio.
+ datatype: integer, uinteger, double, udouble
	Valida os tipos. Não é Obrigatório.
+ rangevalores:
	Valores mínimo e máximo para o controle. Para usá-lo, 
	deve-se passar o datatype. Separe os valores por vírgula.
	Para valores reais, o caracter decimal deve ser o ponto.
	Ex: rangevalores="1.3,28.5" datatype="double" 
		rangevalores="1,28" datatype="integer" 
+ obrigatorio: True ou False
	Não é Obrigatório a passagem deste parametro.
+ expregular:
	Expressão regular que valida o controle. Não é obrigatorio.
	Ex: "\d+"
***********************************************/
function ValidacaoCustomizada(source, arguments)
{
	var texto = arguments.Value;
	var contr = document.getElementById (source.controltovalidate);
	var datatype = "", DataTypeValido = true;
	var obrig = "false", ObrigValido = true;
	var ExpValido = true;
	var label = contr.nomelabel;
	
	if (contr.obrigatorio != null)
	{
		obrig = contr.obrigatorio;
		obrig = obrig.toLowerCase ();	
		if (obrig == "true")
		{
			texto = ValidatorTrim(texto); // Funcao Trim do .NET
			if (texto.length == 0)
			{
				ObrigValido = false;
			}
			arguments.IsValid = ObrigValido;
		}
		else // se nao eh obrigatorio
		{
			if (texto.length == 0)
			{
				arguments.IsValid = true;
				return true; 
			}
		}
		if (! ObrigValido)
		{
			if (label != null)
			{
				//Error message
				source.innerHTML = "O campo " + label + " &eacute; obrigat&oacute;rio.";
				source.setAttribute("errormessage", source.innerHTML);
			}
			return ObrigValido;
		}
	}// fim do if 
	else // se nao eh obrigatorio
	{
		texto = ValidatorTrim(texto); // Funcao Trim do .NET
		if (texto.length == 0)
		{
			arguments.IsValid = true;
			return true;
		}
	}
	if (contr.datatype != null)
	{
		datatype = new String (contr.datatype);
		datatype = datatype.toLowerCase ();
		switch (datatype)
		{
			case "integer":
				var rgexp = /^\s*[-\+]?\d+\s*$/;
				if (texto.match(rgexp) == null)
				{
					DataTypeValido = false;
				}
				else
				{
					if (contr.rangevalores != null)
					{
						var vettmp = contr.rangevalores.split(",");
						if (vettmp.length==2)
						{
							if (parseInt(texto) < vettmp[0])
							{
								if (label != null)
								{
									source.innerHTML = "O campo " + label + " possui um valor abaixo do m&iacute;nimo permitido ("+ vettmp[0] +").";
									source.setAttribute("errormessage", source.innerHTML);
								}
								DataTypeValido = false;
								arguments.IsValid = DataTypeValido;
								return DataTypeValido;
							}
							if (parseInt(texto) > vettmp[1])
							{
								if (label != null)
								{
									source.innerHTML = "O campo " + label + " possui um valor acima do m&aacute;ximo permitido ("+ vettmp[1] +").";
									source.setAttribute("errormessage", source.innerHTML);
								}
								DataTypeValido = false;
								arguments.IsValid = DataTypeValido;
								return DataTypeValido;
							}
						}
					}
				}
				break;
			case "uinteger": // Inteiro Sem Sinal
				var rgexp = /^\s*\d+\s*$/;
				if (texto.match(rgexp) == null)
				{
					DataTypeValido = false;
				}
				else
				{
					if (contr.rangevalores != null)
					{
						var vettmp = contr.rangevalores.split(",");
						if (vettmp.length==2)
						{
							if (parseInt(texto) < vettmp[0])
							{
								if (label != null)
								{
									source.innerHTML = "O campo " + label + " possui um valor abaixo do m&iacute;nimo permitido ("+ vettmp[0] +").";
									source.setAttribute("errormessage", source.innerHTML);
								}
								DataTypeValido = false;
								arguments.IsValid = DataTypeValido;
								return DataTypeValido;
							}
							if (parseInt(texto) > vettmp[1])
							{
								if (label != null)
								{
									source.innerHTML = "O campo " + label + " possui um valor acima do m&aacute;ximo permitido ("+ vettmp[1] +").";
									source.setAttribute("errormessage", source.innerHTML);
								}
								DataTypeValido = false;
								arguments.IsValid = DataTypeValido;
								return DataTypeValido;
							}
						}
					}
				}
				break;
			case "double":
				var caracDecimal = ","; // Caracter Decimal : " , "
				var rgexp = new RegExp("^\\s*([-\\+])?(\\d+)?(\\" + caracDecimal + "(\\d+))?\\s*$");
				if (texto.match(rgexp) == null)
				{
					DataTypeValido = false;
				}
				else
				{
					if (contr.rangevalores != null)
					{
						var vettmp = contr.rangevalores.split(",");
						if (vettmp.length==2)
						{
							if (parseFloat(TrocaVirgula(texto)) < vettmp[0])
							{
								if (label != null)
								{
									source.innerHTML = "O campo " + label + " possui um valor abaixo do m&iacute;nimo permitido ("+ TrocaPonto(vettmp[0]) +").";
									source.setAttribute("errormessage", source.innerHTML);
								}
								DataTypeValido = false;
								arguments.IsValid = DataTypeValido;
								return DataTypeValido;
							}
							if (parseFloat(texto) > vettmp[1])
							{
								if (label != null)
								{
									source.innerHTML = "O campo " + label + " possui um valor acima do m&aacute;ximo permitido ("+ TrocaPonto(vettmp[1]) +").";
									source.setAttribute("errormessage", source.innerHTML);
								}
								DataTypeValido = false;
								arguments.IsValid = DataTypeValido;
								return DataTypeValido;
							}
						}
					}
				}
				break;
			case "udouble": // Double Sem Sinal
				var caracDecimal = ","; // Caracter Decimal : " , "
				var rgexp = new RegExp("^\\s*(\\d+)?(\\" + caracDecimal + "(\\d+))?\\s*$");
				if (texto.match(rgexp) == null)
				{
					DataTypeValido = false;
				}
				else
				{
					if (contr.rangevalores != null)
					{
						var vettmp = contr.rangevalores.split(",");
						if (vettmp.length==2)
						{
							if (parseFloat(TrocaVirgula(texto)) < vettmp[0])
							{
								if (label != null)
								{
									source.innerHTML = "O campo " + label + " possui um valor abaixo do m&iacute;nimo permitido ("+ TrocaPonto(vettmp[0]) +").";
									source.setAttribute("errormessage", source.innerHTML);
								}
								DataTypeValido = false;
								arguments.IsValid = DataTypeValido;
								return DataTypeValido;
							}
							if (parseFloat(texto) > vettmp[1])
							{
								if (label != null)
								{
									source.innerHTML = "O campo " + label + " possui um valor acima do m&aacute;ximo permitido ("+ TrocaPonto(vettmp[1]) +").";
									source.setAttribute("errormessage", source.innerHTML);
								}
								DataTypeValido = false;
								arguments.IsValid = DataTypeValido;
								return DataTypeValido;
							}
						}
					}
				}
				break;
		}// fim do Switch
		arguments.IsValid = DataTypeValido;
		if (! DataTypeValido)
		{
			if (label != null)
			{
				//Error message
				source.innerHTML = "O campo " + label + " n&atilde;o foi preenchido corretamente.";
				source.setAttribute("errormessage", source.innerHTML);
			}
			return DataTypeValido;
		}
	}// fim do If
	
	if (contr.expregular != null)
	{
		var rgexp = new RegExp(contr.expregular);
		if (texto.match(rgexp) == null)
		{
			ExpValido = false;
			if (label != null)
			{
				//Error message
				source.innerHTML = "O campo " + label + " foi preenchido incorretamente.";
				source.setAttribute("errormessage", source.innerHTML);
			}
			arguments.IsValid = ExpValido;
			return ExpValido;
		}
	}// fim do if exp reg
	
	arguments.IsValid = true;
	return true;
}

/***********************************************
Exemplo: 
<body onload="DesativaCustom('CustomValidator1','CustomValidator2')">
reescreve as funcoes de validacao customizada para que teste campos obrigatorios 
dentro da custom validator generica.
***********************************************/
function DesativaCustom()
{
	var vetval = DesativaCustom.arguments;
	for (i=0; i< vetval.length; i++)
	{
		var val = document.getElementById (vetval[i]);
		val.evaluationfunction = function (val)
			{
				var value = "";
				if (typeof(val.controltovalidate) == "string") {
					value = ValidatorGetValue(val.controltovalidate);
				}
				var args = { Value:value, IsValid:true };
				if (typeof(val.clientvalidationfunction) == "string") {
					eval(val.clientvalidationfunction + "(val, args) ;");
				}        
				return args.IsValid;
			}
	}
}
/**********************************************************************************************/
// Valida CPF
function validaCPF(arguments)
{	
	var lsCPFAux;
	var liCont;
	var liCont2;
	var liSoma;
	var liDigito;
	var lsControle = '';
	
	if (arguments.Value != null)
	{
        for(var n=0; n < arguments.Value.length; n++)
        {
            if(!isNaN(arguments.Value.substr(n, 1)))
            {lsControle = lsControle + arguments.Value.substr(n, 1);}
        }
    }
    else
    {
        for(var n=0; n < arguments.value.length; n++)
        {
            if(!isNaN(arguments.value.substr(n, 1)))
            {lsControle = lsControle + arguments.value.substr(n, 1);}
        }
    }
	
	// Adicionar os zeros a esquerda
	var VintResultado;
	var VintTamCampo = lsControle.length;
	VintResultado = 11 - VintTamCampo;

	if(VintResultado > 0 && lsControle != "")
	{
			for(VintControle = 0; VintControle < VintResultado; VintControle++)
			{
				lsControle = "0" + lsControle;
			}		
	}

	lsCPFAux = lsControle.substring(0, 9);
	liSoma = 0;

	if (lsControle == "")
	{
		return true;
	}
	
	var car = lsCPFAux.charAt(0);
	var flag = true;
	for (i=1; i< lsCPFAux.length; i++)
    {
		if (car != lsCPFAux.charAt(i))
		{
			flag = false;
			break;
		}
    }
    if (flag == true)
    {
		return (false);
    }

	var re = /^(\s*)(\d+)(\s*)$/;
	
	if (re.test(lsControle) == false)
	{  
		return false;
	}

	for (liCont2 = 1; liCont2 <= 2; liCont2++)
	{
		for (liCont = lsCPFAux.length; liCont >= 1; liCont--)
		{
			liSoma = liSoma + ((lsCPFAux.length + 2 - liCont) * (eval(lsCPFAux.substring(liCont-1, liCont))));
		}
		liDigito = 11 - (liSoma % 11);
		if (liDigito >= 10)
		{
			liDigito = 0;
		}

		lsCPFAux = lsCPFAux + liDigito;

		liSoma = 0;
	}

	if (lsControle == lsCPFAux) {       
		return true;
	} else {		
		return false;
	}		
}
/**********************************************************************************************/
// Valida CNPJ
function validaCNPJ(arguments)
{			
    var lsCGC;
    var lsCGCAux;
    var liCont;
    var liDigito;
    var liSoma;
    var lsControle = '';

    if (arguments.Value != null)
    {
		if (arguments.Value.length == 15 && arguments.Value.substr(0, 1) == '0')
		{
			arguments.Value = arguments.Value.substr(1, 14);
		}
    
        for(var n=0; n < arguments.Value.length; n++)
        {
            if(!isNaN(arguments.Value.substr(n, 1)))
            {lsControle = lsControle + arguments.Value.substr(n, 1);}
        }
    }
    else
    {
		if (arguments.value.length == 15 && arguments.value.substr(0, 1) == '0')
		{
			arguments.value = arguments.value.substr(1, 14);
		}
		
        for(var n=0; n < arguments.value.length; n++)
        {
            if(!isNaN(arguments.value.substr(n, 1)))
            {lsControle = lsControle + arguments.value.substr(n, 1);}
        }
    
    }
    
	// Adicionar os zeros a esquerda
	var VintResultado;
	var VintTamCampo = lsControle.length;
	VintResultado = 14 - VintTamCampo;

	if(VintResultado > 0 && lsControle != "")
	{
		for(VintControle = 0; VintControle < VintResultado; VintControle++)
		{
			lsControle = "0" + lsControle;
		}
		arguments = lsControle;
	}

	var car = lsControle.charAt(0);
	var flag = true;
	for (i=1; i< lsControle.length; i++)
    {
		if (car != lsControle.charAt(i))
		{
			flag = false;
			break;
		}
    }
    if (flag == true)
    {
		return (false);
    }

	if (lsControle == "")
	{  
		return true;
	}

	var re = /^(\s*)(\d+)(\s*)$/;
	
	if (re.test(lsControle) == false)
	{
		return false;
	}

	if(lsControle.length < 12)
	{	  
		return false;
	}

	lsCGCAux = lsControle.substring(0,12);

	liSoma = 0;

	for (liCont = 2; liCont <= 9; liCont++)
	{
		liSoma = liSoma + (liCont * eval(lsCGCAux.substring(13 - liCont, 14-liCont)));
	}

	for (liCont = 2; liCont <= 5; liCont++)
	{
		liSoma = liSoma + (liCont * eval(lsCGCAux.substring(5 - liCont, 6 - liCont)));
	}

	liDigito = 11 - (liSoma % 11);

	if (liDigito >= 10)
	{
		liDigito = 0;
	}

	lsCGCAux = lsCGCAux + liDigito;

	liSoma = 0;

	for(liCont = 2; liCont <= 9; liCont++)
	{
		liSoma = liSoma + liCont * eval(lsCGCAux.substring(14 - liCont, 15 - liCont));
	}

	for(liCont = 2; liCont <= 6; liCont++)
	{
		liSoma = liSoma + (liCont) * eval(lsCGCAux.substring(6 - liCont, 7 - liCont));
	}

	liDigito = 11 - (liSoma % 11);

	if(liDigito >= 10)
	{
		liDigito = 0;
	}

	lsCGCAux = lsCGCAux + liDigito;

	liSoma = 0;

	if(lsControle == lsCGCAux) {	  
		return true;
	} else {  
		return false;
	}	
 }
/**********************************************************************************************/
// Valida CPF e CNPJ 
function validaCPFCNPJ(controle)
{
	//Chama rotina verifica CPF
	if (validaCPF(controle))
	{
		return true;		
	}
	else
	{	
		//Chama rotina verifica CNPJ
		if (validaCNPJ(controle))
		{
			return true;
		}
		else
		{
			alert('CPF ou CNPJ Inválido!');
			return false;
		}
	}
}
/**********************************************************************************************/
function popup(pag,name,tamx,tamy)
{
    var x = (window.screen.width - tamx) / 2; 
    var y = (window.screen.height - tamy) / 2;
    window.open(pag,name,'scrollbars=1,resizable=1,width=' + tamx + ',height=' + tamy + ',left=' + x + ',top=' + y + ',fullscreen=0,toolbar=0,menubar=0');
}

function popupModal(pag,name,tamx,tamy)
{
    var sFeatures = 'dialogHeight:' + tamy + 'px;dialogWidth:' + tamx + 'px;edge:raised;center:yes;help:no;resizable:no;status:no';
    window.showModalDialog(pag, name, sFeatures);
}
