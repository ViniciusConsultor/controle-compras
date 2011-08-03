
function HabilitaCampo(campo)
{    
    document.getElementById(campo).disabled = false;
}

function DesabilitaCampo(campo)
{
    document.getElementById(campo).disabled = true;
}

function VerificaMatricula(obj, ddlPerfil, ddlCanal, ddlOrdem)
{
    if(obj.value.length > 0)
    {
        DesabilitaCampo(ddlPerfil);
        DesabilitaCampo(ddlCanal);       
        DesabilitaCampo(ddlOrdem);       
    }
    else
    {
        HabilitaCampo(ddlPerfil);
        HabilitaCampo(ddlCanal);
        HabilitaCampo(ddlOrdem);
    }    
}

function VerificaDDl(obj, matricula)
{
    if(obj.value < 0)
    {        
        HabilitaCampo(matricula);
    }
    else
    {
        DesabilitaCampo(matricula);
    }    
}