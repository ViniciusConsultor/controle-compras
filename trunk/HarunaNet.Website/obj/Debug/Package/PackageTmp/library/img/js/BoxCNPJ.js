function exibePainel(tipoPainel, numeroPainel)
{
    document.getElementById(tipoPainel + numeroPainel).style.display = "block";
    document.getElementById("mais" + tipoPainel + numeroPainel).style.display = "none";
    document.getElementById("menos" + tipoPainel + numeroPainel).style.display = "inline";
}

function escondePainel(tipoPainel, numeroPainel)
{
    document.getElementById(tipoPainel + numeroPainel).style.display = "none";
    document.getElementById("mais" + tipoPainel + numeroPainel).style.display = "inline";
    document.getElementById("menos" + tipoPainel + numeroPainel).style.display = "none";
}  
if (typeof (Sys) !== 'undefined') Sys.Application.notifyScriptLoaded();