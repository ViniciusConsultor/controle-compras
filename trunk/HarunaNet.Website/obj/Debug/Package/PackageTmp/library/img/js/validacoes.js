function confirmar(msg)
{
    return confirm(msg);
}
    
function CheckMaxLength(ctrl)
{
	
}

function ltrim(strTexto)
{
   	var strString = new String(strTexto);
    for (I=0;I<strString.length;I++)
    {
    	if (strString.charCodeAt(I)!=32 && strString.charCodeAt(I)!=13 && strString.charCodeAt(I)!=10)
      	{
       		var intInicio = I
       		I = strString.length
     	}
	}
	strString = strString.substring(intInicio,strString.length)
    return strString		
}

/************rtrim tira os espaçamentos da direita************/
function rtrim(strTexto)
{
	var strString = new String(strTexto);
	for (I=strString.length;I>-1;I--)
    {
    	if (strString.charCodeAt(I-1)!=32 && strString.charCodeAt(I-1)!=13 && strString.charCodeAt(I-1)!=10)
    	{
    		var intFim = I 
       		I = 0
     	}
     } 
     strString = strString.substring(0,intFim)
     return strString
}

/*****trim tira os espaçamentos da esquerda e da direita*****/
function trim(strTexto)
{
	var strString = new String(ltrim(rtrim(strTexto)))
	return strString		
}

//Verifica se cep contem 8 digitos e não é zero
function ValidaCep(source, arguments)
{
	
	var strcep = arguments.Value.replace("-","");
	
	if(strcep.length < 8)
	{ 
		arguments.IsValid = false;
		return false;
	}
	else if(strcep == "00000000")
	{ 
		arguments.IsValid = false;
		return false;
	}
}

function Verifica_Zero(source, arguments)
{
	
	var strCampo = arguments.Value.replace("-","");
	
    if(strCampo == 0 || strCampo == "" )
	{ 
		arguments.IsValid = false;
		return false;
	}
}



function ValidaCpf(source, arguments){	
   var lsCPFAux;
   var liCont;
   var liCont2;
   var liSoma;
   var liDigito;
   var lsControle = arguments.Value.replace(".","").replace(".","").replace("-","");
   
   //Manutenção abaixo para adicionar os zeros a esquerda

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
   //fim da manutencao

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
	arguments.IsValid = false;
	return false;
}


function ValidaCnpj(source, arguments){	
    var lsCGC;
    var lsCGCAux;
    var liCont;
    var liDigito;
    var liSoma;
    var lsControle = arguments.Value.replace(".","").replace(".","").replace("/","").replace("-","");
    
    if(lsControle == "00000000000000")
    {
		arguments.IsValid = false;
		return false;
    }

   //Manutenção abaixo para adicionar os zeros a esquerda

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
   //fim da manutencao

if (lsControle == "00000000000000")
 { 
  arguments.IsValid = false;
  return false;
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

   if (lsControle.length < 12)
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

   for (liCont = 2; liCont <= 9; liCont++)
   {
       liSoma = liSoma + liCont * eval(lsCGCAux.substring(14 - liCont, 15 - liCont));
   }

   for (liCont = 2; liCont <= 6; liCont++)
   {
       liSoma = liSoma + (liCont) * eval(lsCGCAux.substring(6 - liCont, 7 - liCont));
   }

   liDigito = 11 - (liSoma % 11);

   if (liDigito >= 10)
   {
       liDigito = 0;
   }

   lsCGCAux = lsCGCAux + liDigito;

   liSoma = 0;

   if (lsControle == lsCGCAux)
   {	  
	  arguments.IsValid = true;
	  return true;
   }
   else
   {  
	  arguments.IsValid = false;
      return false;
   }
 }
 
 function ValidaData(sender, args)
{
	var controle = document.getElementById(sender.getAttribute("ControlToValidate"));
	var resposta = true;
	if(null != controle)
	{
		if("" != trim(controle.value))
		{
			resposta = check_date(controle);
		}
	}
	args.IsValid = resposta;
}

function fValidaData(control)
{
	if(null != control)
	{
		if("" != trim(control.value))
		{
			if(!check_date(control))
			{
				alert("Digite uma data correta.");
				control.value = "";
				control.focus();
			}
		}
	}
}

function check_date(field)
		{
		var checkstr = "0123456789";
		var DateField = field;
		var Datevalue = "";
		var DateTemp = "";
		var seperator = "/";
		var day;
		var month;
		var year;
		var leap = 0;
		var err = 0;
		var i;
		   err = 0;
		   DateValue = DateField.value;
		    /* Delete all chars except 0..9 */
		   for (i = 0; i < DateValue.length; i++) {
			  if (checkstr.indexOf(DateValue.substr(i,1)) >= 0) {
			     DateTemp = DateTemp + DateValue.substr(i,1);
			  }
		   }
		   DateValue = DateTemp;
		   /* Always change date to 8 digits - string*/
		   /* if year is entered as 2-digit / always assume 20xx */
		   if (DateValue.length == 6) {
		      DateValue = DateValue.substr(0,4) + '20' + DateValue.substr(4,2); }
		   if (DateValue.length != 8) {
		      err = 19;}
		   /* year is wrong if year = 0000 */
		   year = DateValue.substr(4,4);
		   if (year == 0) {
		      err = 20;
		   }
		   //If year less than 1900	
		   if (year < 1900 ) {
		      err = 20;
		   }
		   /* Validation of month*/
		   month = DateValue.substr(2,2);
		   if ((month < 1) || (month > 12)) {
		      err = 21;
		   }
		   /* Validation of day*/
		   day = DateValue.substr(0,2);
		   if (day < 1) {
		     err = 22;
		   }
		   /* Validation leap-year / february / day */
		   if ((year % 4 == 0) || (year % 100 == 0) || (year % 400 == 0)) {
		      leap = 1;
		   }
		   if ((month == 2) && (leap == 1) && (day > 29)) {
		      err = 23;
		   }
		   if ((month == 2) && (leap != 1) && (day > 28)) {
		      err = 24;
		   }
		   /* Validation of other months */
		   if ((day > 31) && ((month == "01") || (month == "03") || (month == "05") || (month == "07") || (month == "08") || (month == "10") || (month == "12"))) {
		      err = 25;
		   }
		   if ((day > 30) && ((month == "04") || (month == "06") || (month == "09") || (month == "11"))) {
		      err = 26;
		   }
		   /* if 00 ist entered, no error, deleting the entry */
		   if ((day == 0) && (month == 0) && (year == 00)) {
		      err = 1; day = ""; month = ""; year = ""; seperator = "";
		   }
		   /* if no error, write the completed date to Input-Field (e.g. 13.12.2001) */
		   if (err == 0) {
		      DateField.value = day + seperator + month + seperator + year;
		      return true;
		   }
		   /* Error-message if err != 0 */
		   else {
		      return false;
		   }
		}
		
function check_dateMesAno(field)
		{
		var checkstr = "0123456789";
		var DateField = field;
		var Datevalue = "";
		var DateTemp = "";
		var seperator = "/";
		var day;
		var month;
		var year;
		var leap = 0;
		var err = 0;
		var i;
		   err = 0;
		   DateValue = DateField.value;
		    /* Delete all chars except 0..9 */
		   for (i = 0; i < DateValue.length; i++) {
			  if (checkstr.indexOf(DateValue.substr(i,1)) >= 0) {
			     DateTemp = DateTemp + DateValue.substr(i,1);
			  }
		   }
		   DateValue = DateTemp;
		   /* Always change date to 8 digits - string*/
		   /* if year is entered as 2-digit / always assume 20xx */
		   if (DateValue.length == 4) {
		      DateValue = DateValue.substr(0,2) + '20' + DateValue.substr(2,2); }
		   if (DateValue.length != 6) {
		      err = 19;}
		   /* year is wrong if year = 0000 */
		   year = DateValue.substr(2,4);
		   if (year == 0) {
		      err = 20;
		   }
		   //If year less than 1900	
		   if (year < 1900 ) {
		      err = 20;
		   }
		   /* Validation of month*/
		   month = DateValue.substr(0,2);
		   if ((month < 1) || (month > 12)) {
		      err = 21;
		   }

            day = '01';
            
		   /* Validation leap-year / february / day */
		   if ((year % 4 == 0) || (year % 100 == 0) || (year % 400 == 0)) {
		      leap = 1;
		   }
		   if ((month == 2) && (leap == 1) && (day > 29)) {
		      err = 23;
		   }
		   if ((month == 2) && (leap != 1) && (day > 28)) {
		      err = 24;
		   }
		   /* Validation of other months */
		   if ((day > 31) && ((month == "01") || (month == "03") || (month == "05") || (month == "07") || (month == "08") || (month == "10") || (month == "12"))) {
		      err = 25;
		   }
		   if ((day > 30) && ((month == "04") || (month == "06") || (month == "09") || (month == "11"))) {
		      err = 26;
		   }
		   /* if 00 ist entered, no error, deleting the entry */
		   if ((day == 0) && (month == 0) && (year == 00)) {
		      err = 1; day = ""; month = ""; year = ""; seperator = "";
		   }
		   /* if no error, write the completed date to Input-Field (e.g. 13.12.2001) */
		   if (err == 0) {
		      DateField.value = month + seperator + year;
		      return true;
		   }
		   /* Error-message if err != 0 */
		   else {
		      return false;
		   }
		}		

function ValidaDiferncaData(dtini, dtfim)
{
	
	var datInicio = new Date(dtini.substring(6,10), 
										dtini.substring(3,5), 
										dtini.substring(0,2));
	datInicio.setMonth(datInicio.getMonth() - 1); 
					
					
	var datFim = new Date(dtfim.substring(6,10), 
								dtfim.substring(3,5), 
								dtfim.substring(0,2));
									 
	datFim.setMonth(datFim.getMonth() - 1); 


	if (timeDifference (datFim, datInicio))
	{
		return true;
	}
	else
	{
		alert ('O intervalo para consulta é de 30 dias !! \n Favor informar data válida !');
		return false;
	}
}

function timeDifference(laterdate,earlierdate) 
{
    var difference = laterdate.getTime() - earlierdate.getTime();
    var daysDifference = Math.floor(difference/1000/60/60/24);
    
        
    if (daysDifference > 30)
    {
		return false;
    }
    return true;
}

		function txt_onkeydown(element,e)
		{
			if(!TeclaOK(e.keyCode))
			{
				if(element.value.length < element.maxlength)
					return true;
				else
					return false;
			}
		}
		
		function txt_onkeyup_onblur(element)
		{
			if(element.value.length > element.maxlength)
				element.value = element.value.substring(0,element.maxlength);
		}
		
		function TeclaOK(tecla)
		{
			var BACKSPACE = 8; 
			var TAB = 9;
			var ENTER = 13;
			var DELETE = 46;
		    
			// Setas, Home e End
			if (tecla>=35 && tecla<=40)
				return true;
			
			if ( tecla == ENTER ) 
			{
				window.event.keyCode = TAB;
				return true;
			}
		    
			if ( tecla == BACKSPACE ) 
				return true;
			
			if ( tecla == DELETE ) 
				return true;
			
			if ( tecla == TAB )
				return true;
				
			return false;
		}  // TeclaOK