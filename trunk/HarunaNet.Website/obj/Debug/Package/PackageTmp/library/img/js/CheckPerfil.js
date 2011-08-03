/*			if(tipo="Consulta")
			{
			}
			else
			{
				if(tipo=="Alteração")
				{
				}
				else
				{
					if(tipo=="Exclusão")
					{
						
					}
					else
					{
						
					}
				}
			} 
*/

		function Visualiza()
		{
			window.navigate("admin_perfil_inclusao_confirma.html");
		}
		
		function VisualizaAlteracao()
		{
			window.navigate("admin_perfil_alteracao_confirma.html");
		}
		
		function Retorna()
		{
			if (confirm("O fechamento desta janela resultará na perda dos dados já inseridos. Deseja realmente sair?"))
			{
				window.navigate("admin_perfil.html");
			}
		}	
		
		function SelecionaSimulador(tipo)
		{
			//A lógica ainda está propositalmente errada
			
			//Consulta Simulador
			if (tipo=="Consulta")
			{
				chkConsultaAprovacao.checked = document.getElementById("chkConsultaSimulador").checked;
				chkConsultaCancela.checked = document.getElementById("chkConsultaSimulador").checked;
				chkConsultaRelatorio.checked = document.getElementById("chkConsultaSimulador").checked;
				chkConsultaConsultar.checked = document.getElementById("chkConsultaSimulador").checked;
				chkConsultaNovaSimulacao.checked = document.getElementById("chkConsultaSimulador").checked;
			}
			else
			{
				if(tipo=="Alteração")
				{
							
					//Alteração Simulador
					
					chkAlteraAprovacao.checked = document.getElementById("chkAlteraSimulador").checked;
					chkAlteraCancelar.checked = document.getElementById("chkAlteraSimulador").checked;
					chkAlteraConsultar.checked = document.getElementById("chkAlteraSimulador").checked;
					chkAlteraNovaSimulacao.checked = document.getElementById("chkAlteraSimulador").checked;
					chkAlteraRelatorios.checked = document.getElementById("chkAlteraSimulador").checked;

				}
				else
				{
					if(tipo=="Exclusão")
					{
						//Exclusão Simulador	
						chkExclusaoAprovacao.checked = document.getElementById("chkExclusaoSimulador").checked;
						chkExclusaoCancelar.checked = document.getElementById("chkExclusaoSimulador").checked;
						chkExclusaoConsultar.checked = document.getElementById("chkExclusaoSimulador").checked;
						chkExclusaoNovaSimulacao.checked = document.getElementById("chkExclusaoSimulador").checked;
						chkExclusaoRelatorios.checked = document.getElementById("chkExclusaoSimulador").checked;

					}
					else
					{
						//Impressão Simulador
						chkImpressaoAprovacao.checked = document.getElementById("chkImpressaoSimulador").checked;
						chkImpressaoCancelar.checked = document.getElementById("chkImpressaoSimulador").checked;
						chkImpressaoConsultar.checked = document.getElementById("chkImpressaoSimulador").checked;
						chkImpressaoNovaSimulacao.checked = document.getElementById("chkImpressaoSimulador").checked;
						chkImpressaoRelatorios.checked = document.getElementById("chkImpressaoSimulador").checked;
						
					}
				}
			} 
		}
		
		function SelecionaAdministracao()
		{
			
			
			//Consulta Administração
			if(tipo="Consulta")
			{
				chkConsultaControledeAcesso.checked = chkConsultaAdministracao.checked;
				chkConsultaAdministracaoSimulador.checked = chkConsultaAdministracao.checked;
				SelecionaAdministracaoSimulador("Consulta");
				SelecionaControleAcesso("Consulta");

			}
			else
			{
				if(tipo=="Alteração")
				{
					//Alteração Administração
					
					chkAlteraControledeAcesso.checked = chkAlteraAdminstracao.checked;
					chkAlteraAdministracaoSimulador.checked = chkAlteraAdminstracao.checked;
					SelecionaAdministracaoSimulador("Alteração");
					SelecionaControleAcesso("Alteração");

				}
				else
				{
					if(tipo=="Exclusão")
					{
	
			
						//Exclusao Administração
			
						chkExclusaoControledeAcesso.checked = chkExclusaoAdministracao.checked;
						chkExclusaoAdministracaoSimulador.checked = chkExclusaoAdministracao.checked;
						SelecionaAdministracaoSimulador("Exclusão");
						SelecionaControleAcesso("Exclusão");

					}
					else
					{
						//Impressão Administração
			
						chkImpressaoControledeAcesso.checked = chkImpressaoAdministracao.checked;
						chkImpressaoAdministracaoSimulador.checked = chkImpressaoAdministracao.checked;
						SelecionaAdministracaoSimulador("Impressão");
						SelecionaControleAcesso("Impressão");

					}
				}
			} 
			
		}
		
		function SelecionaControleAcesso()
		{
			if(tipo="Consulta")
			{
	
				//Consulta Controle Acesso
				
				chkConsultaUsuario.checked = chkConsultaControledeAcesso.checked;
				chkConsultaPerfil.checked = chkConsultaControledeAcesso.checked;
				chkConsultaCanais.checked = chkConsultaControledeAcesso.checked;
			
						}
			else
			{
				if(tipo=="Alteração")
				{

					//Alteração Controle Acesso
					
					chkAlteraUsuario.checked = chkAlteraControledeAcesso.checked;
					chkAlteraPerfil.checked = chkAlteraControledeAcesso.checked;
					chkAlteraCanais.checked = chkAlteraControledeAcesso.checked;
				}
				else
				{
					if(tipo=="Exclusão")
					{
			
						//Exclusão Controle Acesso
						
						chkExclusaoUsuario.checked = chkExclusaoControledeAcesso.checked;
						chkExclusaoPerfil.checked = chkExclusaoControledeAcesso.checked;
						chkExclusaoCanais.checked = chkExclusaoControledeAcesso.checked;			
						
					}
					else
					{
						//Impressão Controle Acesso
						
						chkImpressãoUsuario.checked = chkImpressãoControledeAcesso.checked;
						chkImpressãoPerfil.checked = chkImpressãoControledeAcesso.checked;
						chkImpressãoCanais.checked = chkImpressãoControledeAcesso.checked;
						
					}
				}
			} 
			
			
			
		}
		
			
		function SelecionaAdministracaoSimulador()
		{
			if(tipo="Consulta")
			{
				chkConsultaParametrosdeMC.checked = chkConsultaAdministracaoSimulador.checked; 
				chkConsultaFormulas.checked = chkConsultaAdministracaoSimulador.checked; 
				chkConsultaTabelas.checked = chkConsultaAdministracaoSimulador.checked; 
				chkConsultaCRV.checked = chkConsultaAdministracaoSimulador.checked; 
			}
			else
			{
				if(tipo=="Alteração")
				{
			
					chkAlteraParametrosdeMC.checked = chkAlteraAdministracaoSimulador.checked; 
					chkAlteraFormulas.checked = chkAlteraAdministracaoSimulador.checked; 
					chkAlteraTabelas.checked = chkAlteraAdministracaoSimulador.checked; 
					chkAlteraCRV.checked = chkAlteraAdministracaoSimulador.checked; 
				}
				else
				{
					if(tipo=="Exclusão")
					{
						
						chkExclusaoParametrosdeMC.checked = chkExclusaoAdministracaoSimulador.checked; 
						chkExclusaoFormulas.checked = chkExclusaoAdministracaoSimulador.checked; 
						chkExclusaoTabelas.checked = chkExclusaoAdministracaoSimulador.checked; 
						chkExclusaoCRV.checked = chkExclusaoAdministracaoSimulador.checked; 
					}
					else
					{
						chkImpressaoParametrosdeMC.checked = chkImpressaoAdministracaoSimulador.checked; 
						chkImpressaoFormulas.checked = chkImpressaoAdministracaoSimulador.checked; 
						chkImpressaoTabelas.checked = chkImpressaoAdministracaoSimulador.checked; 
						chkImpressaoCRV.checked = chkImpressaoAdministracaoSimulador.checked; 			
					}
				}
			} 
					
		}
		
		function SelecionaFichaCadastral()
		{
			if(tipo="Consulta")
			{

				chkConsultaFichaCadastralConsultar.checked = chkConsultaFichaCadastral.checked;
				chkConsultaAlterar.checked = chkConsultaFichaCadastral.checked;
				chkConsultaCadastrar.checked = chkConsultaFichaCadastral.checked;
						}
			else
			{
				if(tipo=="Alteração")
				{
					chkAlteraFichaCadastralConsultar.checked = chkAlteraFichaCadastral.checked;
					chkAlteraAlterar.checked = chkAlteraFichaCadastral.checked;
					chkAlteraCadastrar.checked = chkAlteraFichaCadastral.checked;
				}
				else
				{
					if(tipo=="Exclusão")
					{
						
						chkExclusaoFichaCadastralConsultar.checked = chkExclusaoFichaCadastral.checked;
						chkExclusaoAlterar.checked = chkExclusaoFichaCadastral.checked;
						chkExclusaoCadastrar.checked = chkExclusaoFichaCadastral.checked;
					}
					else
					{
		
						chkImpressaoFichaCadastralConsultar.checked = chkImpressaoFichaCadastral.checked;
						chkImpressaoAlterar.checked = chkImpressaoFichaCadastral.checked;
						chkImpressaoCadastrar.checked = chkImpressaoFichaCadastral.checked;
												
					}
				}
			} 
			
		}			

