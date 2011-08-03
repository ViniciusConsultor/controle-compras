using System;
using System.Collections.Generic;
using System.Text;

namespace HarunaNet.Framework.Utils
{
    /// <summary>
    /// Classe com funções de uso geral
    /// </summary>
    public partial class Consts
    {
        /// <summary>
        /// Classe com rotinas pré-definidas em JavaScript para utilização em conjunto com instruções
        /// de registro de script em páginas ASP.NET
        /// </summary>
        public class JavaScript
        {
            /// <summary>
            /// [Deprecada] Tag de Início de rotinas JavaScript.
            /// Caso utilize em ASP.NET 2.0 ou acima, prefira utilizar o parâmetro
            /// addScriptTags = true das rotinas de registro de script.
            /// </summary>
            public static string Begin =
                "<script language=javascript>\n";

            /// <summary>
            /// [Deprecada] Tag de fechamento de rotinas JavaScript.
            /// Caso utilize em ASP.NET 2.0 ou acima, prefira utilizar o parâmetro
            /// addScriptTags = true das rotinas de registro de script.
            /// </summary>
            public static string End =
                "</script>";

            /// <summary>
            /// Corpo da função de impressão de elementos HTML em uma página HTML puro. (PrintElementID)
            /// </summary>
            /// <seealso cref="PrintElementID"/>
            public static string ScriptPrintElementID =
                "function PrintElementID(id, pg) \n" +
                "{ \n" +
                "	var oPrint, oJan; \n" +
                "	oPrint = window.document.getElementById(id).innerHTML; \n" +
                "	oJan = window.open(pg); \n" +
                "	oJan.document.write(oPrint); \n" +
                "	oJan.history.go(); \n" +
                "	oJan.window.print(); \n" +
                "} \n";

            /// <summary>
            /// Corpo da função de Impressão de conteúdo HTML em página HTML vazia (PrintCustomPage)
            /// </summary>
            /// <seealso cref="PrintPageCustom"/>
            public static string ScriptPrintPageCustom =
                "function PrintCustomPage(content, pg) \n" +
                "{ \n" +
                "	var oPrint, oJan; \n" +
                "	oPrint = content; \n" +
                "	oJan = window.open(pg); \n" +
                "	oJan.document.write(oPrint); \n" +
                "	oJan.history.go(); \n" +
                "	oJan.window.print(); \n" +
                "} \n";

            /// <summary>
            /// Corpo da função de limpeza de caixa de texto (clearTexts)
            /// </summary>
            public static string ScriptClearTexts =
                "function clearTexts(sender)\n" +
                "{\n" +
                "		var form = window.document.forms[sender]\n" +
                "		for (var i=0; i < form.elements.length; i++)\n" +
                "		{\n" +
                "			if ( (form.elements[i].type == 'text') || (form.elements[i].type == 'textarea') )\n" +
                "			{\n" +
                "				form.elements[i].value = '';\n" +
                "			}\n" +
                "		}\n" +
                "}\n";

            /// <summary>
            /// Corpo da função de abertura de páginas pop-ups (AbrePopUp)
            /// </summary>
            public static string ScriptPopUp =
                "function AbrePopUp(pagina,jan,w,h,s,rz)\n" +
                "{\n" +
                "	LeftPosition=(screen.width)?(screen.width-w)/2:100;\n" +
                "	TopPosition=(screen.height)?(screen.height-h)/2:100;\n" +
                "	settings='toolbar=no,location=no,status=no,directories=no,scrollbars='+s+',copyhistory=no,menubar=no,width='+w+',height='+h+',left='+LeftPosition +',top='+TopPosition + ',resizable='+rz;\n" +
                "	window.open(pagina,jan,settings);\n" +
                "}\n";

            /// <summary>
            /// Corpo da função de posicionamento de div no sentro da tela
            /// O nome do elemento HTML DEVE se chamar dvProgresso
            /// </summary>
            public static string ScriptPosicionaDivProgresso =
                "function PosicionaDivProgresso() \n " +
                "{ \n " +
                "	$get('dvProgresso').style.left = (screen.width)?(screen.width-100)/2:100; \n " +
                "	$get('dvProgresso').style.top = (screen.height)?(screen.height-100)/2:100; \n " +
                "} \n";

            /// <summary>
            /// Corpo da função de prevenção de digitação dos caracteres ASC 193,111,189,109,190 e 194
            /// </summary>
            public static string ScriptNoDot =
                "function NoDot(Campo, teclapres)\n" +
                "{\n" +
                "	var tecla = teclapres.keyCode;\n" +
                "	if (tecla == 193 || tecla == 111 || tecla == 189 || tecla == 109 || tecla == 190 || tecla == 194)\n" +
                "	{\n" +
                "		var vr = new String(Campo.value);\n" +
                "		tam = vr.length;\n" +
                "		Campo.value = vr.substr(0, tam-1);\n" +
                "		return true;\n" +
                "	}\n" +
                "}\n";

            /// <summary>
            /// Corpo da função de formatação de data, para colocar o caracter "/" automaticamente
            /// </summary>
            public static string ScriptFormatDate =
                "function FormataData(Campo, teclapres)\n" +
                "{\n" +
                "	var tecla = teclapres.keyCode;\n" +
                "	if (tecla == 193 || tecla == 111 || tecla == 189 || tecla == 109)\n" +
                "		return true;\n" +
                "	var vr = new String(Campo.value);\n" +
                "	vr = vr.replace(\"/\", \"\");\n" +
                "	vr = vr.replace(\"/\", \"\");\n" +
                "	tam = vr.length + 1;\n" +
                "	if (tecla != 9 && tecla != 8)\n" +
                "	{\n" +
                "		if (tam > 2 && tam < 5)\n" +
                "			Campo.value = vr.substr(0, 2) + '/' + vr.substr(2, tam);\n" +
                "		if (tam >= 5 && tam <=10)\n" +
                "			Campo.value = vr.substr(0,2) + '/' + vr.substr(2,2) + '/' + vr.substr(4,4);\n" +
                "	}\n" +
                "}\n";

            /// <summary>
            /// Corpo da função de formatação de hora, para colocar o caracter ":" automaticamente
            /// </summary>
            public static string ScriptFormatTime =
                "function FormataHora(Campo, teclapres)\n" +
                "{\n" +
                "	var tecla = teclapres.keyCode;\n" +
                "	if (tecla == 193 || tecla == 111 || tecla == 189 || tecla == 109)\n" +
                "		return true;\n" +
                "	var vr = new String(Campo.value);\n" +
                "	vr = vr.replace(\":\", \"\");\n" +
                "	vr = vr.replace(\":\", \"\");\n" +
                "	tam = vr.length + 1;\n" +
                "	if (tecla != 9 && tecla != 8)\n" +
                "	{\n" +
                "		if (tam > 2 && tam < 5)\n" +
                "			Campo.value = vr.substr(0, 2) + ':' + vr.substr(2, tam);\n" +
                "		if (tam >= 5 && tam <=10)\n" +
                "			Campo.value = Campo.value; //vr.substr(0,2) + ':' + vr.substr(2,2) + ':' + vr.substr(4,4);\n" +
                "	}\n" +
                "}\n";


            /// <summary>
            /// Corpo da função javascript FormataCompt
            /// </summary>
            public static string ScriptFormatCompt =
                "function FormataCompt(Campo, teclapres)\n" +
                "{\n" +
                "	var tecla = teclapres.keyCode;\n" +
                "	if (tecla == 193 || tecla == 111 || tecla == 189 || tecla == 109)\n" +
                "		return true;\n" +
                "	var vr = new String(Campo.value);\n" +
                "	vr = vr.replace(\"/\", \"\");\n" +
                "	tam = vr.length + 1;\n" +
                "	if (tecla != 9 && tecla != 8)\n" +
                "	{\n" +
                "		if (tam > 2 && tam < 5)\n" +
                "			Campo.value = vr.substr(0, 2) + '/' + vr.substr(2, tam);\n" +
                "	}\n" +
                "}\n";

            /// <summary>
            /// Corpo da função javascript SemBarras, que evita a digtação dos caracteres ASC 193,111,189 e 109
            /// </summary>
            public static string ScriptNoBar =
                "function SemBarras(Campo, teclapres)\n" +
                "{\n" +
                "	var tecla = teclapres.keyCode;\n" +
                "	if (tecla == 193 || tecla == 111 || tecla == 189 || tecla == 109)\n" +
                "	{\n" +
                "		var vr = new String(Campo.value);\n" +
                "		tam = vr.length;\n" +
                "		Campo.value = vr.substr(0, tam-1);\n" +
                "		return true;\n" +
                "	}\n" +
                "}\n";

            /// <summary>
            /// Função de aplicação da rotina javascript clearTexts
            /// </summary>
            /// <param name="sender">Nome do controle HTML a ser aplicada a limpeza de texto</param>
            /// <param name="regTag">Indica se será acrescentadas tags de abertura e fechamento de script</param>
            /// <returns>Função formatada e pronta para utilização nos controles HTML das páginas</returns>
            /// <remarks>O script ScriptClearTexts DEVE ser registrado na página</remarks>
            /// <seealso cref="ScriptClearTexts"/>
            public static string clearText(string sender, bool regTag)
            {
                if (regTag == true)
                    return Begin + String.Format("clearTexts({0});\n", sender) + End;
                else
                    return String.Format("clearTexts({0});\n", sender);
            }

            /// <summary>
            /// Função de aplicação da rotina javascript PosicionaDivProgresso
            /// </summary>
            /// <returns>Função formatada e pronta para utilização nos controles html da página</returns>
            /// <remarks>O script ScriptPosicionaDivProgresso DEVE ser registrado na página</remarks>
            /// <seealso cref="ScriptPosicionaDivProgresso"/>
            public static string PosicionaDivProgresso()
            {
                return "PosicionaDivProgresso();";
            }

            /// <summary>
            /// Função de aplicação da rotina JavaScript AbrePopUp nos controles HTML
            /// </summary>
            /// <param name="url">URL a ser aberta na janela de destino</param>
            /// <param name="windowName">Nome da janela de destino</param>
            /// <param name="W">Largura da janela de destino, informada em pixels</param>
            /// <param name="H">Altura da janela de destino, informada em pixels</param>
            /// <param name="Scroll">Indica se haverão barras de rolagem (yes/no)</param>
            /// <param name="Resize">Indica se a janela pode ser redimensionada (yes/no)</param>
            /// <param name="regTag">Indica se serão acrescentadas tags de abertura e fechamento de script</param>
            /// <returns>Função pronta e formatada para utilização nos controles HTML na página</returns>
            /// <remarks>O script ScriptPopUp DEVE ser registrado na página</remarks>
            /// <seealso cref="ScriptPopUp"/>
            public static string openWindow(string url, string windowName, string W, string H, string Scroll, string Resize, bool regTag)
            {
                if (regTag == true)
                    return Begin + String.Format("AbrePopUp('{0}','{1}',{2},{3},'{4}','{5}');\n", url, windowName, W, H, Scroll, Resize) + End;
                else
                    return String.Format("AbrePopUp('{0}','{1}',{2},{3},'{4}','{5}');", url, windowName, W, H, Scroll, Resize);
            }

            /// <summary>
            /// Função JavaScript para fechar a janela
            /// </summary>
            /// <param name="regTag">Indica se serão acrescentadas tags de abertura e fechamento de script.</param>
            /// <returns>Função formatada e pronta para utlização em eventos javascript nas páginas</returns>
            public static string closeWindow(bool regTag)
            {
                if (regTag == true)
                    return Begin + "window.close();\n" + End;
                else
                    return "window.close();";
            }

            /// <summary>
            /// Função de aplicação da rotina NoDot nos controles HTML
            /// </summary>
            /// <returns>Função formatada e pronta para utilização nas páginas HTML</returns>
            /// <remarks>O script ScriptNoDot DEVE ser registrado na página</remarks>
            /// <seealso cref="ScriptNoDot"/>
            public static string noDot()
            {
                return "NoDot(this,event);";
            }

            /// <summary>
            /// Função JavaScript de validação da digitação da tecla ENTER;
            /// Não permite o pressionamento do ENTER nos controles onde a função é aplicada.
            /// </summary>
            /// <returns>Função formatada e pronta para utilização nas páginas HTML</returns>
            public static string noReturn()
            {
                string script = "" +
                    "	var tecla = event.keyCode;\n" +
                    "	if (tecla == 13)\n" +
                    "	{\n" +
                    "		alert('Não Permitido !');\n" +
                    "		return false;\n" +
                    "	}\n";

                return script;
            }

            /// <summary>
            /// Função javascript de validação de campos numéricos; permite que apenas números sejam digitados
            /// em controles HTML
            /// </summary>
            /// <returns>Função pronta para utilização em eventos javascript nas páginas</returns>
            public static string OnlyNumber()
            {
                string script = "" +
                    "	var tecla = event.keyCode;\n" +
                    "	if ( ((tecla >= 48) && (tecla <= 57)) || ((tecla >= 96) && (tecla <= 105)) || ((tecla >= 8) && (tecla <= 9)) || ((tecla >= 37) && (tecla <= 40)) || (tecla == 144) || (tecla == 46)  )\n" +
                    "   {\n}\n " +
                    "	else \n	" +
                    "	{\n" +
                    "		alert('Só algarismos de [0..9] são permitido !');\n" +
                    "		return false;\n" +
                    "	}\n";

                return script;
            }

            /// <summary>
            /// Função JavaScript para formatação de fórmulas (2X, por exemplo)
            /// </summary>
            /// <returns>Função formatada e pronta para uso em eventos javascript nas páginas</returns>
            public static string OnlyFomula()
            {
                string script = "" +
                    "	var tecla = event.keyCode;\n" +
                    "	if ( ((tecla >= 48) && (tecla <= 57)) || ((tecla >= 96) && (tecla <= 105)) || ((tecla >= 8) && (tecla <= 9)) || ((tecla >= 37) && (tecla <= 40)) || (tecla == 144) || (tecla == 46) || (tecla == 88) || (tecla == 111) || (tecla == 193) || (tecla == 107) || (tecla == 187) || (tecla == 16) )\n" +
                    "   {\n}\n " +
                    "	else \n	" +
                    "	{\n" +
                    "		alert('Apenas os seguinte digitos são validos para formula:[0..9][X][/][+]!');\n" +
                    "		return false;\n" +
                    "	}\n";

                return script;
            }

            /// <summary>
            /// Função de aplicação da rotina javascript SemBarras
            /// </summary>
            /// <returns>Função formatada e pronta para utilização nos eventos javascript da página</returns>
            /// <remarks>O script ScriptNoBar DEVE ser registrado na página</remarks>
            /// <seealso cref="ScriptNoBar"/>
            public static string noBar()
            {
                return "SemBarras(this,event);";
            }

            /// <summary>
            /// Função de aplicação da rotina javascript FormataData
            /// </summary>
            /// <param name="regTag">Indica se será acrescentadas as tags de abertura e fechamento de script</param>
            /// <returns>Função formatada e pronta para utilização em eventos javascript nas páginas</returns>
            /// <remarks>O script ScriptFormatDate DEVE ser registrado na página</remarks>
            /// <seealso cref="ScriptFormatDate"/>
            public static string formatDate(bool regTag)
            {
                if (regTag == true)
                    return Begin + "FormataData(this,event);\n" + End;
                else
                    return "FormataData(this,event);";
            }

            /// <summary>
            /// Função de aplicação da rotina FormataHora.
            /// </summary>
            /// <param name="regTag">Indica se serão acrescentadas tags de abertura e fechamento de script</param>
            /// <returns>Função formatada e pronta para utilização em eventos javascript na página</returns>
            /// <remarks>O script ScriptFormatTime DEVE ser registrado na página</remarks>
            /// <seealso cref="ScriptFormatTime"/>
            public static string formatTime(bool regTag)
            {
                if (regTag == true)
                    return Begin + "FormataHora(this,event);\n" + End;
                else
                    return "FormataHora(this,event);";
            }

            /// <summary>
            /// Função de aplicação da função FormataCompt.
            /// </summary>
            /// <param name="regTag">Indica se serão acrescentadas tags de abertura e fechamento de script</param>
            /// <returns>Função pronta e formatada para utilização em eventos javascript da página</returns>
            /// <remarks>O script ScriptFormatCompt DEVE ser registrado na página</remarks>
            /// <seealso cref="ScriptFormatCompt"/>
            public static string formatCompt(bool regTag)
            {
                if (regTag == true)
                    return Begin + "FormataCompt(this,event);\n" + End;
                else
                    return "FormataCompt(this,event);";
            }

            /// <summary>
            /// Função para disparar um alerta em JavaScript
            /// </summary>
            /// <param name="mens">Mensagem a ser mostrada para o usuário</param>
            /// <param name="regTag">Indica se serão acrescentadas tags de abertura e fechamento de script</param>
            /// <returns>Função alert pronta para ser utilizada em eventos de javascript da página</returns>
            public static string Alert(string mens, bool regTag)
            {
                if (regTag == true)
                    return Begin + String.Format("alert('{0}');\n", mens) + End;
                else
                    return String.Format("alert('{0}');", mens);
            }

            /// <summary>
            /// Seta um elemento de página HTML na página pai em que a função foi chamada.
            /// </summary>
            /// <param name="att">Propriedade do elemento a ser setada</param>
            /// <param name="name">Nome do elemento a ser setado</param>
            /// <param name="controlname">Indica se será utilizada aspas no nome do controle</param>
            /// <param name="v">Valor a ser setado na propriedade do elemento</param>
            /// <param name="controlvalue">Indica se será utilizada aspas no valor do atributo</param>
            /// <param name="regTag">Indica se será acrescentadas tags de abertura e fechamento de script na função</param>
            /// <returns>Função pronta para ser utilizada em eventos javascript da página</returns>
            public static string setParentElementAtt(string att, string name, bool controlname, string v, bool controlvalue, bool regTag)
            {
                string Attribute = "";
                string aspasv = "";
                string aspasn = "";

                if (controlvalue == true)
                    aspasv = "";
                else
                    aspasv = "\"";

                if (controlname == true)
                    aspasn = "";
                else
                    aspasn = "\"";

                switch (att.ToUpper().Trim())
                {
                    case "VALUE":
                        Attribute = att.ToLower() + "=" + aspasv + v + aspasv + ";\n";
                        break;
                    case "CLICK":
                        Attribute = att.ToLower() + "();\n";
                        break;
                    default:
                        goto case "VALUE";
                }

                if (regTag == true)
                    return Begin + "window.opener.document.getElementById(" + aspasn + name + aspasn + ")." + Attribute + End;
                else
                    return "window.opener.document.getElementById(" + aspasn + name + aspasn + ")." + Attribute;
            }

            /// <summary>
            /// Seta o foco em um componente da página
            /// </summary>
            /// <param name="control">Nome no HTML do controle a ser setado o foco</param>
            /// <param name="regTag">Indica se serão acrescentadas as tags de abertura e fechamento de script</param>
            /// <returns>Função montada, pronta para utilização em eventos javascript da página</returns>
            public static string setFocus(string control, bool regTag)
            {
                if (regTag == true)
                    return Begin + "window.document.getElementById(\"" + control + "\").focus();\n" + End;
                else
                    return "window.document.getElementById(\"" + control + "\").focus();\n";
            }

            /// <summary>
            /// Coloca o foco em um componente da página pai em que a função foi chamada
            /// </summary>
            /// <param name="control">Nome do controle (nome no resultado HTML) a ser setado o foco</param>
            /// <param name="regTag">Indica se serão acrescentadas tags de abertura e fechamento de script</param>
            /// <returns>Função montada, pronta para utilização em eventos javascript da página</returns>
            /// <remarks>DEVE haver uma página pai, pois a função é executada em uma página de nível inferior à página chamadora da função.</remarks>
            public static string setParentFocus(string control, bool regTag)
            {
                if (regTag == true)
                    return Begin + "window.opener.document.getElementById(\"" + control + "\").focus();\n" + End;
                else
                    return "window.opener.document.getElementById(\"" + control + "\").focus();\n";
            }

            /// <summary>
            /// Função JavaScript de confirmação Sim/Não.
            /// </summary>
            /// <param name="Mensagem">Mensagem a ser exibida ao usuário</param>
            /// <returns>Função Confirm JavaScript, ideal para utilização de confirmação antes do post da página.</returns>
            /// <example>
            /// <code>
            /// botaoExcluir.ClientClick = Consts.JavaScript.ConfirmationDialog("Tem Certeza?");
            /// </code> 
            ///</example>
            public static string ConfirmationDialog(string Mensagem)
            {
                return "return confirm('" + Mensagem + "');";
            }

            /// <summary>
            /// Navega para um destino utilizando JavaScript, abrindo a página na janela pai da página em que a rotina é chamada
            /// </summary>
            /// <param name="url">URL de destino</param>
            /// <param name="regTag">Indica se serão acescentadas as tags de abertura e fechamento de script</param>
            /// <returns>Função montada, pronta para utilização em eventos JavaScripts de componentes ou da própria página</returns>
            /// <remarks>DEVE haver uma página pai, pois a função é executada na página de nível imediatamente inferior ao da janela aberta. Caso contrário, ocorrerá erro.</remarks>
            public static string parentNavigate(string url, bool regTag)
            {
                if (regTag == true)
                {
                    return Begin + "window.opener.navigate('" + url + "');" + End;
                }
                else
                {
                    return "window.opener.navigate('" + url + "');";
                }
            }

            /// <summary>
            /// Navega para um destino utilizando JavaScript, abrindo a página na mesma janela da pagina em que foi chamada.
            /// </summary>
            /// <param name="url">URL de destino da navegação</param>
            /// <param name="regTag">Indica se serão acrescentadas tags de abertura e fechamento de scripts</param>
            /// <returns>Função montada, pronta para ser utilizada em eventos javascript de componentes de tela ou execução ao carregar página</returns>
            public static string Navigate(string url, bool regTag)
            {
                if (regTag == true)
                {
                    return Begin + "window.navigate('" + url + "');" + End;
                }
                else
                {
                    return "window.navigate('" + url + "');";
                }
            }

            /// <summary>
            /// Função de chamada da rotina javascript PrintElementID (impressão de elemento HTML),
            /// para ser associada a eventos de componentes de tela.
            /// </summary>
            /// <param name="pElementoID">Nome do elemento HTML a ser impresso</param>
            /// <param name="pJanelaDestino">Página de saída da impressão do elemento</param>
            /// <returns>Chamada da função montada, pronta para ser utilizada em rotinas de eventos JavaScript de componentes de tela</returns>
            /// <remarks>Registrar o script ScriptPrintElementID na página</remarks>
            /// <seealso cref="ScriptPrintElementID"/>
            public static string PrintElementID(string pElementoID, string pJanelaDestino)
            {
                return "PrintElementID('" + pElementoID + "','" + pJanelaDestino + "');";
            }

            /// <summary>
            /// Função de chamada da rotina PrintCustomPage (Impressão de conteúdo HTML) , para ser associada a eventos JavaScript
            /// de componentes de tela;
            /// </summary>
            /// <param name="pConteudo">Conteúdo HTML a ser impresso</param>
            /// <param name="pJanelaDestino">Página em que o conteúdo será impresso</param>
            /// <returns>String contendo a função montada. Utilizar nas rotinas de eventos JavaScript de componentes de tela</returns>
            /// <remarks>Registrar o script PrintCustomPage na página</remarks>
            /// <seealso cref="ScriptPrintPageCustom"/>
            public static string PrintPageCustom(string pConteudo, string pJanelaDestino)
            {
                return "PrintCustomPage('" + pConteudo + "','" + pJanelaDestino + "');";
            }

            /// <summary>
            /// Registra evento JavaScript de mudança de classe CSS no foco ou na perda dele em um componente HTML
            /// </summary>
            /// <param name="ClasseNormal">Indica a classe CSS atual dos elementos em que serão aplicados os efeito</param>
            /// <param name="ClasseOnFocus">Classe CSS a ser atribuída no foco (evento onFocus)</param>
            /// <returns>Função javascript formatada e pronta para ser colocada na página</returns>
            /// <remarks>NECESSÁRIO utilização do framework javascript JQuery 1.2.3 para funcionar, portanto, declará-lo na página.
            /// Este script DEVE ser registrado no corpo da página (body), não no header. 
            ///</remarks>
            public static string ScriptTrocaCSSOnFocus(string ClasseNormal, string ClasseOnFocus)
            {
                string script = "$('." + ClasseNormal + "').focus(function(){" +
                                "  $(this).toggleClass('" + ClasseOnFocus + "');" +
                                "});" +
                                "$('." + ClasseNormal + "').blur(function(){" +
                                "$(this).toggleClass('" + ClasseOnFocus + "');" +
                                "});";
                return script;
            }

            /// <summary>
            /// Aplica uma máscara de formatação em um elemento HTML
            /// </summary>
            /// <param name="NomeElemHTML">Nome (ID no browser) do elemento HTML a ser aplicada a máscara</param>
            /// <param name="Mask">Máscara a ser aplicada: a -> alfabético, somente; 9 -> numérico, somente; * -> alfanumérico</param>
            /// <returns>Função javascript pronta para utilizalção</returns>
            /// <remarks>NECESSÁRIO registrar no header da página, juntamente com os arquivos javascript
            /// JQuery e o plugin MaskedInput (http://digitalbush.com/projects/masked-input-plugin). 
            ///</remarks>
            public static string ScriptMask(string NomeElemHTML, string Mask)
            {
                string script = "$(function() {" +
                                "$('#" + NomeElemHTML + "').mask('" + Mask + "');" +
                                "});";
                return script;
            }

            /// <summary>
            /// Aplica o efeito TabSheet sobre um div
            /// </summary>
            /// <param name="container">Nome do div que contém os ítens do tabsheet</param>
            /// <returns>Script pronto para ser utilizado na página</returns>
            /// <remarks>
            /// Necessário colocar este script no header da página
            /// Necessário referenciar o plugin UI Tabs do JQuery (http://stilbuero.de/2006/05/13/accessible-unobtrusive-javascript-tabs-with-jquery/)
            /// </remarks>
            public static string InitJQueryUITabs(string container)
            {
                string script = "$(function(){" +
                                "    $(\"#" + container + " > ul\").tabs(); " +
                                "  });";
                return script;
            }

            /// <summary>
            /// Inicializa um tabsheet JQuery com uma tab selecionada e/ou seleciona uma tab
            /// </summary>
            /// <param name="container">Nome do contêiner que contém o tabsheet produzido pelo JQuery</param>
            /// <param name="TabSelected">Tab a ser selecionada, começando a partir do zero</param>
            /// <returns>Script pronto para ser utilizado na página</returns>
            /// <remarks>
            /// Necessário colocar este script no header da página
            /// Necessário referenciar o plugin UI Tabs do JQuery (http://stilbuero.de/2006/05/13/accessible-unobtrusive-javascript-tabs-with-jquery/)
            /// </remarks>
            public static string SelectJQueryUITab(string container, int TabSelected)
            {
                string script = "$(function(){" +
                                "    $(\"#" + container + " > ul\").tabs('select'," + TabSelected.ToString() + "); " +
                                "  });";
                return script;
            }

        }
    }
}
