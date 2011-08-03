function ExibePopup(val)
{
    var oPopup = $(val);
    $("<div class='desabilitar' id='popup_" + oPopup.attr("id") + "' />").insertBefore(oPopup);
    $("h1 a", oPopup).click(function(){HidePopup(val)});
    oPopup.show();
    oPopup.css("margin-top", (oPopup.height() / 2) * -1);
    oPopup.css("margin-left", (750 - oPopup.width()) / 2);
    
    //$("td :first", oPopup).focus();
}

function HidePopup(val)
{
    oPopup = $(val)
    oPopup.hide(function()
    {
        $(".desabilitar[id='popup_" + oPopup.attr("id") + "']").remove();
    });
}