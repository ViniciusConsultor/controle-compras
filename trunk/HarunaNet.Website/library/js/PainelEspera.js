Sys.Application.add_init(Init);
//Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(PainelEsperaBeginRequestHandler);
//Sys.WebForms.PageRequestManager.getInstance().add_endRequest(PainelEsperaEndRequestHandler);

function Init(sender)
{
  var prm = Sys.WebForms.PageRequestManager.getInstance();
  if (prm)
  {
      if (!prm.get_isInAsyncPostBack())
      {
            prm.add_beginRequest(BeginRequest);
            prm.add_endRequest(EndRequest);
      }
  }
}

function BeginRequest(sender,args)
{
    var painelEspera = $find('PainelEsperaExtender');
    painelEspera._backgroundElement.style.zIndex = "20000";
    painelEspera._foregroundElement.style.zIndex = "20001";+		
    painelEspera.show();
}

function EndRequest(sender,args)
{
   $find('PainelEsperaExtender').hide();
}