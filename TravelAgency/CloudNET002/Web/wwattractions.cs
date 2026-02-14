using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class wwattractions : GXDataArea
   {
      public wwattractions( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("TravelAgency", true);
      }

      public wwattractions( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavOrderedby = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
            gxfirstwebparm_bkp = gxfirstwebparm;
            gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               dyncall( GetNextPar( )) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
            {
               setAjaxEventMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
            {
               gxnrGrid_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid") == 0 )
            {
               gxgrGrid_refresh_invoke( ) ;
               return  ;
            }
            else
            {
               if ( ! IsValidAjaxCall( false) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = gxfirstwebparm_bkp;
            }
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_29 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_29"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_29_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_29_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_29_idx = GetPar( "sGXsfl_29_idx");
         AV12Update = GetPar( "Update");
         AV13Delete = GetPar( "Delete");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid_newrow( ) ;
         /* End function gxnrGrid_newrow_invoke */
      }

      protected void gxgrGrid_refresh_invoke( )
      {
         subGrid_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid_Rows"), "."), 18, MidpointRounding.ToEven));
         cmbavOrderedby.FromJSonString( GetNextPar( ));
         AV16OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV11AttractionName = GetPar( "AttractionName");
         AV15CountryName = GetPar( "CountryName");
         AV14ADVANCED_LABEL_TEMPLATE = GetPar( "ADVANCED_LABEL_TEMPLATE");
         AV12Update = GetPar( "Update");
         AV13Delete = GetPar( "Delete");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV16OrderedBy, AV11AttractionName, AV15CountryName, AV14ADVANCED_LABEL_TEMPLATE, AV12Update, AV13Delete) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid_refresh_invoke */
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("general.ui.masterunanimosidebar", "GeneXus.Programs.general.ui.masterunanimosidebar", new Object[] {context});
            MasterPageObj.setDataArea(this,false);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         cleanup();
      }

      public override short ExecuteStartEvent( )
      {
         PA0E2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0E2( ) ;
         }
         return gxajaxcallmode ;
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
         context.WriteHtmlTextNl( "</title>") ;
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( StringUtil.Len( sDynURL) > 0 )
         {
            context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
         }
         define_styles( ) ;
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
         CloseStyles();
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 239440), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 239440), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 239440), false, true);
         context.AddJavascriptSource("gxcfg.js", "?"+GetCacheInvalidationToken( ), false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         if ( StringUtil.StrCmp(context.GetLanguageProperty( "rtl"), "true") == 0 )
         {
            context.WriteHtmlText( " dir=\"rtl\" ") ;
         }
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwattractions.aspx") +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "vADVANCED_LABEL_TEMPLATE", StringUtil.RTrim( AV14ADVANCED_LABEL_TEMPLATE));
         GxWebStd.gx_hidden_field( context, "gxhash_vADVANCED_LABEL_TEMPLATE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV14ADVANCED_LABEL_TEMPLATE, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16OrderedBy), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vATTRACTIONNAME", StringUtil.RTrim( AV11AttractionName));
         GxWebStd.gx_hidden_field( context, "GXH_vCOUNTRYNAME", StringUtil.RTrim( AV15CountryName));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_29", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_29), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vADVANCED_LABEL_TEMPLATE", StringUtil.RTrim( AV14ADVANCED_LABEL_TEMPLATE));
         GxWebStd.gx_hidden_field( context, "gxhash_vADVANCED_LABEL_TEMPLATE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV14ADVANCED_LABEL_TEMPLATE, "")), context));
         GxWebStd.gx_hidden_field( context, "COUNTRYID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A9CountryId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "FILTERSCONTAINER_Class", StringUtil.RTrim( divFilterscontainer_Class));
         GxWebStd.gx_hidden_field( context, "COUNTRYNAMEFILTERCONTAINER_Class", StringUtil.RTrim( divCountrynamefiltercontainer_Class));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         context.WriteHtmlTextNl( "</form>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE0E2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0E2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("wwattractions.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWAttractions" ;
      }

      public override string GetPgmdesc( )
      {
         return "Attractions" ;
      }

      protected void WB0E0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"none\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "body-container", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridcell_Internalname, 1, 0, "px", 0, "px", divGridcell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtable_Internalname, 1, 0, "px", 0, "px", "container-fluid container-advanced", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabletop_Internalname, 1, 0, "px", 0, "px", "Flex ww__actions-container", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "ww__title-cell", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTitletext_Internalname, "Attractions", "", "", lblTitletext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_WWAttractions.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "ww__actions-cell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 15,'',false,'',0)\"";
            ClassString = "Button button-primary";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(29), 2, 0)+","+"null"+");", "Insert", bttBtninsert_Jsonclick, 5, "Insert", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWAttractions.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "ww__filter-cell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAttractionname_Internalname, "Attraction Name", "gx-form-item attribute-searchLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'" + sGXsfl_29_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAttractionname_Internalname, StringUtil.RTrim( AV11AttractionName), StringUtil.RTrim( context.localUtil.Format( AV11AttractionName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,18);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Name", edtavAttractionname_Jsonclick, 0, "attribute-search", "", "", "", "", 1, edtavAttractionname_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWAttractions.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "ww__toggle-cell", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(29), 2, 0)+","+"null"+");", "Show Filters", bttBtntoggle_Jsonclick, 7, bttBtntoggle_Tooltiptext, "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e110e1_client"+"'", TempTags, "", 2, "HLP_WWAttractions.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridcontainer_Internalname, 1, 0, "px", 0, "px", "ww__grid-container", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl29( ) ;
         }
         if ( wbEnd == 29 )
         {
            wbEnd = 0;
            nRC_GXsfl_29 = (int)(nGXsfl_29_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
               GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 col-md-2 ww__filters-cell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divFilterscontainer_Internalname, 1, 0, "px", 0, "px", divFilterscontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "end", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
            ClassString = "filters-container__close";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggleontable_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(29), 2, 0)+","+"null"+");", "Hide Filters", bttBtntoggleontable_Jsonclick, 7, "Hide Filters", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e110e1_client"+"'", TempTags, "", 2, "HLP_WWAttractions.htm");
            GxWebStd.gx_div_end( context, "end", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavOrderedby_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavOrderedby_Internalname, "Ordered By", "col-xs-12 attribute-comboLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'" + sGXsfl_29_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavOrderedby, cmbavOrderedby_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV16OrderedBy), 4, 0)), 1, cmbavOrderedby_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavOrderedby.Enabled, 0, 0, 0, "em", 0, "", "", "attribute-combo", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "", true, 0, "HLP_WWAttractions.htm");
            cmbavOrderedby.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16OrderedBy), 4, 0));
            AssignProp("", false, cmbavOrderedby_Internalname, "Values", (string)(cmbavOrderedby.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCountrynamefiltercontainer_Internalname, 1, 0, "px", 0, "px", divCountrynamefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcountrynamefilter_Internalname, lblLblcountrynamefilter_Caption, "", "", lblLblcountrynamefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "filter-item__label", 0, "", 1, 1, 0, 1, "HLP_WWAttractions.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 filter-item__cell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCountryname_Internalname, "Country Name", "col-sm-3 attribute-comboLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'" + sGXsfl_29_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCountryname_Internalname, StringUtil.RTrim( AV15CountryName), StringUtil.RTrim( context.localUtil.Format( AV15CountryName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCountryname_Jsonclick, 0, "attribute-combo", "", "", "", "", edtavCountryname_Visible, edtavCountryname_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWAttractions.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 29 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
                  GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START0E2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_10-184260", 0) ;
            }
         }
         Form.Meta.addItem("description", "Attractions", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0E0( ) ;
      }

      protected void WS0E2( )
      {
         START0E2( ) ;
         EVT0E2( ) ;
      }

      protected void EVT0E2( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               sEvt = cgiGet( "_EventName");
               EvtGridId = cgiGet( "_EventGridId");
               EvtRowId = cgiGet( "_EventRowId");
               if ( StringUtil.Len( sEvt) > 0 )
               {
                  sEvtType = StringUtil.Left( sEvt, 1);
                  sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                  if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
                  {
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E120E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRIDPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_29_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_29_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_29_idx), 4, 0), 4, "0");
                              SubsflControlProps_292( ) ;
                              A7AttractionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtAttractionId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A8AttractionName = cgiGet( edtAttractionName_Internalname);
                              A10CountryName = cgiGet( edtCountryName_Internalname);
                              A12CategoryName = cgiGet( edtCategoryName_Internalname);
                              A13AttractionPhoto = cgiGet( edtAttractionPhoto_Internalname);
                              AssignProp("", false, edtAttractionPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A13AttractionPhoto)) ? A40000AttractionPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A13AttractionPhoto))), !bGXsfl_29_Refreshing);
                              AssignProp("", false, edtAttractionPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A13AttractionPhoto), true);
                              A15CityName = cgiGet( edtCityName_Internalname);
                              AV12Update = cgiGet( edtavUpdate_Internalname);
                              AssignAttri("", false, edtavUpdate_Internalname, AV12Update);
                              AV13Delete = cgiGet( edtavDelete_Internalname);
                              AssignAttri("", false, edtavDelete_Internalname, AV13Delete);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E130E2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E140E2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E150E2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Orderedby Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ".", ",") != Convert.ToDecimal( AV16OrderedBy )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Attractionname Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vATTRACTIONNAME"), AV11AttractionName) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Countryname Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCOUNTRYNAME"), AV15CountryName) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE0E2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA0E2( )
      {
         if ( nDonePA == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            init_web_controls( ) ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavAttractionname_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_292( ) ;
         while ( nGXsfl_29_idx <= nRC_GXsfl_29 )
         {
            sendrow_292( ) ;
            nGXsfl_29_idx = ((subGrid_Islastpage==1)&&(nGXsfl_29_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_29_idx+1);
            sGXsfl_29_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_29_idx), 4, 0), 4, "0");
            SubsflControlProps_292( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV16OrderedBy ,
                                       string AV11AttractionName ,
                                       string AV15CountryName ,
                                       string AV14ADVANCED_LABEL_TEMPLATE ,
                                       string AV12Update ,
                                       string AV13Delete )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF0E2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_ATTRACTIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A7AttractionId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "ATTRACTIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A7AttractionId), 4, 0, ".", "")));
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( cmbavOrderedby.ItemCount > 0 )
         {
            AV16OrderedBy = (short)(Math.Round(NumberUtil.Val( cmbavOrderedby.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV16OrderedBy), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV16OrderedBy", StringUtil.LTrimStr( (decimal)(AV16OrderedBy), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavOrderedby.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16OrderedBy), 4, 0));
            AssignProp("", false, cmbavOrderedby_Internalname, "Values", cmbavOrderedby.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF0E2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV17Pgmname = "WWAttractions";
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      protected void RF0E2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 29;
         /* Execute user event: Refresh */
         E140E2 ();
         nGXsfl_29_idx = 1;
         sGXsfl_29_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_29_idx), 4, 0), 4, "0");
         SubsflControlProps_292( ) ;
         bGXsfl_29_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "ww__grid");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_292( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV11AttractionName ,
                                                 AV15CountryName ,
                                                 A8AttractionName ,
                                                 A10CountryName ,
                                                 AV16OrderedBy } ,
                                                 new int[]{
                                                 TypeConstants.SHORT
                                                 }
            });
            lV11AttractionName = StringUtil.PadR( StringUtil.RTrim( AV11AttractionName), 50, "%");
            lV15CountryName = StringUtil.PadR( StringUtil.RTrim( AV15CountryName), 50, "%");
            /* Using cursor H000E2 */
            pr_default.execute(0, new Object[] {lV11AttractionName, lV15CountryName, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_29_idx = 1;
            sGXsfl_29_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_29_idx), 4, 0), 4, "0");
            SubsflControlProps_292( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A14CityId = H000E2_A14CityId[0];
               n14CityId = H000E2_n14CityId[0];
               A11CategoryId = H000E2_A11CategoryId[0];
               n11CategoryId = H000E2_n11CategoryId[0];
               A9CountryId = H000E2_A9CountryId[0];
               A15CityName = H000E2_A15CityName[0];
               A40000AttractionPhoto_GXI = H000E2_A40000AttractionPhoto_GXI[0];
               AssignProp("", false, edtAttractionPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A13AttractionPhoto)) ? A40000AttractionPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A13AttractionPhoto))), !bGXsfl_29_Refreshing);
               AssignProp("", false, edtAttractionPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A13AttractionPhoto), true);
               A12CategoryName = H000E2_A12CategoryName[0];
               A10CountryName = H000E2_A10CountryName[0];
               A8AttractionName = H000E2_A8AttractionName[0];
               A7AttractionId = H000E2_A7AttractionId[0];
               A13AttractionPhoto = H000E2_A13AttractionPhoto[0];
               AssignProp("", false, edtAttractionPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A13AttractionPhoto)) ? A40000AttractionPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A13AttractionPhoto))), !bGXsfl_29_Refreshing);
               AssignProp("", false, edtAttractionPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A13AttractionPhoto), true);
               A12CategoryName = H000E2_A12CategoryName[0];
               A10CountryName = H000E2_A10CountryName[0];
               A15CityName = H000E2_A15CityName[0];
               /* Execute user event: Grid.Load */
               E150E2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 29;
            WB0E0( ) ;
         }
         bGXsfl_29_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0E2( )
      {
         GxWebStd.gx_hidden_field( context, "vADVANCED_LABEL_TEMPLATE", StringUtil.RTrim( AV14ADVANCED_LABEL_TEMPLATE));
         GxWebStd.gx_hidden_field( context, "gxhash_vADVANCED_LABEL_TEMPLATE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV14ADVANCED_LABEL_TEMPLATE, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_ATTRACTIONID"+"_"+sGXsfl_29_idx, GetSecureSignedToken( sGXsfl_29_idx, context.localUtil.Format( (decimal)(A7AttractionId), "ZZZ9"), context));
      }

      protected int subGrid_fnc_Pagecount( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV11AttractionName ,
                                              AV15CountryName ,
                                              A8AttractionName ,
                                              A10CountryName ,
                                              AV16OrderedBy } ,
                                              new int[]{
                                              TypeConstants.SHORT
                                              }
         });
         lV11AttractionName = StringUtil.PadR( StringUtil.RTrim( AV11AttractionName), 50, "%");
         lV15CountryName = StringUtil.PadR( StringUtil.RTrim( AV15CountryName), 50, "%");
         /* Using cursor H000E3 */
         pr_default.execute(1, new Object[] {lV11AttractionName, lV15CountryName});
         GRID_nRecordCount = H000E3_AGRID_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID_nRecordCount) ;
      }

      protected int subGrid_fnc_Recordsperpage( )
      {
         if ( subGrid_Rows > 0 )
         {
            return subGrid_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrid_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nFirstRecordOnPage/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgrid_firstpage( )
      {
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV16OrderedBy, AV11AttractionName, AV15CountryName, AV14ADVANCED_LABEL_TEMPLATE, AV12Update, AV13Delete) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ( GRID_nRecordCount >= subGrid_fnc_Recordsperpage( ) ) && ( GRID_nEOF == 0 ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV16OrderedBy, AV11AttractionName, AV15CountryName, AV14ADVANCED_LABEL_TEMPLATE, AV12Update, AV13Delete) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         if ( GRID_nFirstRecordOnPage >= subGrid_fnc_Recordsperpage( ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage-subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV16OrderedBy, AV11AttractionName, AV15CountryName, AV14ADVANCED_LABEL_TEMPLATE, AV12Update, AV13Delete) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( GRID_nRecordCount > subGrid_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-subGrid_fnc_Recordsperpage( ));
            }
            else
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV16OrderedBy, AV11AttractionName, AV15CountryName, AV14ADVANCED_LABEL_TEMPLATE, AV12Update, AV13Delete) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV16OrderedBy, AV11AttractionName, AV15CountryName, AV14ADVANCED_LABEL_TEMPLATE, AV12Update, AV13Delete) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void subgrid_varsfromstate( )
      {
         if ( GridState.FilterCount >= 1 )
         {
            AV11AttractionName = GridState.FilterValues("Attractionname");
            AssignAttri("", false, "AV11AttractionName", AV11AttractionName);
            AV15CountryName = GridState.FilterValues("Countryname");
            AssignAttri("", false, "AV15CountryName", AV15CountryName);
         }
         if ( GridState.OrderedBy != 0 )
         {
            AV16OrderedBy = GridState.OrderedBy;
            AssignAttri("", false, "AV16OrderedBy", StringUtil.LTrimStr( (decimal)(AV16OrderedBy), 4, 0));
         }
         if ( GridState.CurrentPage > 0 )
         {
            GridPageCount = subGrid_fnc_Pagecount( );
            if ( ( GridPageCount > 0 ) && ( GridPageCount < GridState.CurrentPage ) )
            {
               subgrid_gotopage( GridPageCount) ;
            }
            else
            {
               subgrid_gotopage( ((GridPageCount<0) ? 0 : GridState.CurrentPage)) ;
            }
         }
      }

      protected void subgrid_varstostate( )
      {
         GridState.CurrentPage = subGrid_fnc_Currentpage( );
         GridState.OrderedBy = AV16OrderedBy;
         GridState.ClearFilterValues();
         GridState.AddFilterValue("AttractionName", AV11AttractionName);
         GridState.AddFilterValue("CountryName", AV15CountryName);
      }

      protected void before_start_formulas( )
      {
         AV17Pgmname = "WWAttractions";
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
         edtAttractionId_Enabled = 0;
         edtAttractionName_Enabled = 0;
         edtCountryName_Enabled = 0;
         edtCategoryName_Enabled = 0;
         edtAttractionPhoto_Enabled = 0;
         edtCityName_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0E0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E130E2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_29 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_29"), ".", ","), 18, MidpointRounding.ToEven));
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            AV11AttractionName = cgiGet( edtavAttractionname_Internalname);
            AssignAttri("", false, "AV11AttractionName", AV11AttractionName);
            cmbavOrderedby.Name = cmbavOrderedby_Internalname;
            cmbavOrderedby.CurrentValue = cgiGet( cmbavOrderedby_Internalname);
            AV16OrderedBy = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavOrderedby_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV16OrderedBy", StringUtil.LTrimStr( (decimal)(AV16OrderedBy), 4, 0));
            AV15CountryName = cgiGet( edtavCountryname_Internalname);
            AssignAttri("", false, "AV15CountryName", AV15CountryName);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ".", ",") != Convert.ToDecimal( AV16OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vATTRACTIONNAME"), AV11AttractionName) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCOUNTRYNAME"), AV15CountryName) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E130E2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E130E2( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV17Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV17Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         subGrid_Rows = 5;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         AV12Update = "Update";
         AssignAttri("", false, edtavUpdate_Internalname, AV12Update);
         AV13Delete = "Delete";
         AssignAttri("", false, edtavDelete_Internalname, AV13Delete);
         AV16OrderedBy = 1;
         AssignAttri("", false, "AV16OrderedBy", StringUtil.LTrimStr( (decimal)(AV16OrderedBy), 4, 0));
         edtavCountryname_Visible = 0;
         AssignProp("", false, edtavCountryname_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCountryname_Visible), 5, 0), true);
         Form.Caption = "Attractions";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV14ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
         AssignAttri("", false, "AV14ADVANCED_LABEL_TEMPLATE", AV14ADVANCED_LABEL_TEMPLATE);
         GxWebStd.gx_hidden_field( context, "gxhash_vADVANCED_LABEL_TEMPLATE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV14ADVANCED_LABEL_TEMPLATE, "")), context));
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         GridState.LoadGridState();
      }

      protected void E140E2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         GridState.SaveGridState();
         bttBtntoggle_Class = "ww__button-filters--show";
         AssignProp("", false, bttBtntoggle_Internalname, "Class", bttBtntoggle_Class, true);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV15CountryName)) )
         {
            lblLblcountrynamefilter_Caption = "Country Name";
            AssignProp("", false, lblLblcountrynamefilter_Internalname, "Caption", lblLblcountrynamefilter_Caption, true);
         }
         else
         {
            bttBtntoggle_Class = "ww__button-filters--applied";
            AssignProp("", false, bttBtntoggle_Internalname, "Class", bttBtntoggle_Class, true);
            lblLblcountrynamefilter_Caption = StringUtil.Format( AV14ADVANCED_LABEL_TEMPLATE, "Country Name", AV15CountryName, "", "", "", "", "", "", "");
            AssignProp("", false, lblLblcountrynamefilter_Internalname, "Caption", lblLblcountrynamefilter_Caption, true);
         }
         /*  Sending Event outputs  */
      }

      private void E150E2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         edtavUpdate_Link = formatLink("attractions.aspx", new object[] {UrlEncode(StringUtil.RTrim("UPD")),UrlEncode(StringUtil.LTrimStr(A7AttractionId,4,0))}, new string[] {"Mode","AttractionId"}) ;
         edtavDelete_Link = formatLink("attractions.aspx", new object[] {UrlEncode(StringUtil.RTrim("DLT")),UrlEncode(StringUtil.LTrimStr(A7AttractionId,4,0))}, new string[] {"Mode","AttractionId"}) ;
         edtAttractionName_Link = formatLink("viewattractions.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A7AttractionId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"AttractionId","TabCode"}) ;
         edtCountryName_Link = formatLink("viewcountry.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A9CountryId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"CountryId","TabCode"}) ;
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 29;
         }
         sendrow_292( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_29_Refreshing )
         {
            DoAjaxLoad(29, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E120E2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         CallWebObject(formatLink("attractions.aspx", new object[] {UrlEncode(StringUtil.RTrim("INS")),UrlEncode(StringUtil.LTrimStr(0,1,0))}, new string[] {"Mode","AttractionId"}) );
         context.wjLocDisableFrm = 1;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV17Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "Attractions";
         AV6Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA0E2( ) ;
         WS0E2( ) ;
         WE0E2( ) ;
         cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20262142054995", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages.eng.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("wwattractions.js", "?20262142054996", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_292( )
      {
         edtAttractionId_Internalname = "ATTRACTIONID_"+sGXsfl_29_idx;
         edtAttractionName_Internalname = "ATTRACTIONNAME_"+sGXsfl_29_idx;
         edtCountryName_Internalname = "COUNTRYNAME_"+sGXsfl_29_idx;
         edtCategoryName_Internalname = "CATEGORYNAME_"+sGXsfl_29_idx;
         edtAttractionPhoto_Internalname = "ATTRACTIONPHOTO_"+sGXsfl_29_idx;
         edtCityName_Internalname = "CITYNAME_"+sGXsfl_29_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_29_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_29_idx;
      }

      protected void SubsflControlProps_fel_292( )
      {
         edtAttractionId_Internalname = "ATTRACTIONID_"+sGXsfl_29_fel_idx;
         edtAttractionName_Internalname = "ATTRACTIONNAME_"+sGXsfl_29_fel_idx;
         edtCountryName_Internalname = "COUNTRYNAME_"+sGXsfl_29_fel_idx;
         edtCategoryName_Internalname = "CATEGORYNAME_"+sGXsfl_29_fel_idx;
         edtAttractionPhoto_Internalname = "ATTRACTIONPHOTO_"+sGXsfl_29_fel_idx;
         edtCityName_Internalname = "CITYNAME_"+sGXsfl_29_fel_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_29_fel_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_29_fel_idx;
      }

      protected void sendrow_292( )
      {
         sGXsfl_29_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_29_idx), 4, 0), 4, "0");
         SubsflControlProps_292( ) ;
         WB0E0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_29_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
         {
            GridRow = GXWebRow.GetNew(context,GridContainer);
            if ( subGrid_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
            }
            else if ( subGrid_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid_Backstyle = 0;
               subGrid_Backcolor = subGrid_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Uniform";
               }
            }
            else if ( subGrid_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
               subGrid_Backcolor = (int)(0x0);
            }
            else if ( subGrid_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( ((int)((nGXsfl_29_idx) % (2))) == 0 )
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Even";
                  }
               }
               else
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Odd";
                  }
               }
            }
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"ww__grid"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_29_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAttractionId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A7AttractionId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A7AttractionId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAttractionId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column column-optional",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)29,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "attribute-description";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAttractionName_Internalname,StringUtil.RTrim( A8AttractionName),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtAttractionName_Link,(string)"",(string)"",(string)"",(string)edtAttractionName_Jsonclick,(short)0,(string)"attribute-description",(string)"",(string)ROClassString,(string)"column",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)50,(short)0,(short)0,(short)29,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCountryName_Internalname,StringUtil.RTrim( A10CountryName),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtCountryName_Link,(string)"",(string)"",(string)"",(string)edtCountryName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column column-optional",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)50,(short)0,(short)0,(short)29,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCategoryName_Internalname,StringUtil.RTrim( A12CategoryName),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCategoryName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column column-optional",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)50,(short)0,(short)0,(short)29,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "ImageAttribute";
            StyleString = "";
            A13AttractionPhoto_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A13AttractionPhoto))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000AttractionPhoto_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A13AttractionPhoto)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A13AttractionPhoto)) ? A40000AttractionPhoto_GXI : context.PathToRelativeUrl( A13AttractionPhoto));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtAttractionPhoto_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)0,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"column column-optional",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)A13AttractionPhoto_IsBlob,(bool)true,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCityName_Internalname,StringUtil.RTrim( A15CityName),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCityName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column column-optional",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)50,(short)0,(short)0,(short)29,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_29_idx + "',29)\"";
            ROClassString = "TextActionAttribute TextLikeLink";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,StringUtil.RTrim( AV12Update),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavUpdate_Link,(string)"",(string)"",(string)"",(string)edtavUpdate_Jsonclick,(short)0,(string)"TextActionAttribute TextLikeLink",(string)"",(string)ROClassString,(string)"WWTextActionColumn",(string)"",(short)-1,(int)edtavUpdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)29,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'" + sGXsfl_29_idx + "',29)\"";
            ROClassString = "TextActionAttribute TextLikeLink";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,StringUtil.RTrim( AV13Delete),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavDelete_Link,(string)"",(string)"",(string)"",(string)edtavDelete_Jsonclick,(short)0,(string)"TextActionAttribute TextLikeLink",(string)"",(string)ROClassString,(string)"WWTextActionColumn",(string)"",(short)-1,(int)edtavDelete_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)29,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes0E2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_29_idx = ((subGrid_Islastpage==1)&&(nGXsfl_29_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_29_idx+1);
            sGXsfl_29_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_29_idx), 4, 0), 4, "0");
            SubsflControlProps_292( ) ;
         }
         /* End function sendrow_292 */
      }

      protected void init_web_controls( )
      {
         cmbavOrderedby.Name = "vORDEREDBY";
         cmbavOrderedby.WebTags = "";
         cmbavOrderedby.addItem("1", "Name", 0);
         cmbavOrderedby.addItem("2", "Country", 0);
         if ( cmbavOrderedby.ItemCount > 0 )
         {
            AV16OrderedBy = (short)(Math.Round(NumberUtil.Val( cmbavOrderedby.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV16OrderedBy), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV16OrderedBy", StringUtil.LTrimStr( (decimal)(AV16OrderedBy), 4, 0));
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl29( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"29\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "ww__grid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid_Backcolorstyle == 0 )
            {
               subGrid_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid_Class) > 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Title";
               }
            }
            else
            {
               subGrid_Titlebackstyle = 1;
               if ( subGrid_Backcolorstyle == 1 )
               {
                  subGrid_Titlebackcolor = subGrid_Allbackcolor;
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"attribute-description"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Country Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Category Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ImageAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Photo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "City Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"TextActionAttribute TextLikeLink"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"TextActionAttribute TextLikeLink"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridContainer.AddObjectProperty("GridName", "Grid");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               GridContainer = new GXWebGrid( context);
            }
            else
            {
               GridContainer.Clear();
            }
            GridContainer.SetWrapped(nGXWrapped);
            GridContainer.AddObjectProperty("GridName", "Grid");
            GridContainer.AddObjectProperty("Header", subGrid_Header);
            GridContainer.AddObjectProperty("Class", "ww__grid");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", "");
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A7AttractionId), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A8AttractionName)));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtAttractionName_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A10CountryName)));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtCountryName_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A12CategoryName)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", context.convertURL( A13AttractionPhoto));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A15CityName)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV12Update)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV13Delete)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDelete_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectedindex), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowselection), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectioncolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowhovering), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Hoveringcolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowcollapsing), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         lblTitletext_Internalname = "TITLETEXT";
         bttBtninsert_Internalname = "BTNINSERT";
         edtavAttractionname_Internalname = "vATTRACTIONNAME";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         divTabletop_Internalname = "TABLETOP";
         edtAttractionId_Internalname = "ATTRACTIONID";
         edtAttractionName_Internalname = "ATTRACTIONNAME";
         edtCountryName_Internalname = "COUNTRYNAME";
         edtCategoryName_Internalname = "CATEGORYNAME";
         edtAttractionPhoto_Internalname = "ATTRACTIONPHOTO";
         edtCityName_Internalname = "CITYNAME";
         edtavUpdate_Internalname = "vUPDATE";
         edtavDelete_Internalname = "vDELETE";
         divGridcontainer_Internalname = "GRIDCONTAINER";
         divGridtable_Internalname = "GRIDTABLE";
         divGridcell_Internalname = "GRIDCELL";
         bttBtntoggleontable_Internalname = "BTNTOGGLEONTABLE";
         cmbavOrderedby_Internalname = "vORDEREDBY";
         lblLblcountrynamefilter_Internalname = "LBLCOUNTRYNAMEFILTER";
         edtavCountryname_Internalname = "vCOUNTRYNAME";
         divCountrynamefiltercontainer_Internalname = "COUNTRYNAMEFILTERCONTAINER";
         divFilterscontainer_Internalname = "FILTERSCONTAINER";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGrid_Internalname = "GRID";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("TravelAgency", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         subGrid_Header = "";
         edtavDelete_Jsonclick = "";
         edtavDelete_Link = "";
         edtavDelete_Enabled = 0;
         edtavUpdate_Jsonclick = "";
         edtavUpdate_Link = "";
         edtavUpdate_Enabled = 0;
         edtCityName_Jsonclick = "";
         edtCategoryName_Jsonclick = "";
         edtCountryName_Jsonclick = "";
         edtCountryName_Link = "";
         edtAttractionName_Jsonclick = "";
         edtAttractionName_Link = "";
         edtAttractionId_Jsonclick = "";
         subGrid_Class = "ww__grid";
         subGrid_Backcolorstyle = 0;
         edtCityName_Enabled = 0;
         edtAttractionPhoto_Enabled = 0;
         edtCategoryName_Enabled = 0;
         edtCountryName_Enabled = 0;
         edtAttractionName_Enabled = 0;
         edtAttractionId_Enabled = 0;
         edtavCountryname_Jsonclick = "";
         edtavCountryname_Enabled = 1;
         edtavCountryname_Visible = 1;
         lblLblcountrynamefilter_Caption = "Country Name";
         cmbavOrderedby_Jsonclick = "";
         cmbavOrderedby.Enabled = 1;
         bttBtntoggle_Class = "ww__button-filters--hide";
         bttBtntoggle_Tooltiptext = "Show Filters";
         edtavAttractionname_Jsonclick = "";
         edtavAttractionname_Enabled = 1;
         divGridcell_Class = "col-xs-12 col-sm-9 col-md-10 ww__grid-cell--expanded";
         divCountrynamefiltercontainer_Class = "filters-container__item";
         divFilterscontainer_Class = "filters-container";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Attractions";
         subGrid_Rows = 5;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"cmbavOrderedby"},{"av":"AV16OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV11AttractionName","fld":"vATTRACTIONNAME"},{"av":"AV12Update","fld":"vUPDATE"},{"av":"AV13Delete","fld":"vDELETE"},{"av":"AV15CountryName","fld":"vCOUNTRYNAME"},{"av":"AV14ADVANCED_LABEL_TEMPLATE","fld":"vADVANCED_LABEL_TEMPLATE","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"ctrl":"BTNTOGGLE","prop":"Class"},{"av":"lblLblcountrynamefilter_Caption","ctrl":"LBLCOUNTRYNAMEFILTER","prop":"Caption"}]}""");
         setEventMetadata("'TOGGLE'","""{"handler":"E110E1","iparms":[{"av":"divFilterscontainer_Class","ctrl":"FILTERSCONTAINER","prop":"Class"}]""");
         setEventMetadata("'TOGGLE'",""","oparms":[{"av":"divFilterscontainer_Class","ctrl":"FILTERSCONTAINER","prop":"Class"},{"av":"divGridcell_Class","ctrl":"GRIDCELL","prop":"Class"},{"ctrl":"BTNTOGGLE","prop":"Tooltiptext"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E150E2","iparms":[{"av":"A7AttractionId","fld":"ATTRACTIONID","pic":"ZZZ9","hsh":true},{"av":"A9CountryId","fld":"COUNTRYID","pic":"ZZZ9"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"edtavUpdate_Link","ctrl":"vUPDATE","prop":"Link"},{"av":"edtavDelete_Link","ctrl":"vDELETE","prop":"Link"},{"av":"edtAttractionName_Link","ctrl":"ATTRACTIONNAME","prop":"Link"},{"av":"edtCountryName_Link","ctrl":"COUNTRYNAME","prop":"Link"}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E120E2","iparms":[{"av":"A7AttractionId","fld":"ATTRACTIONID","pic":"ZZZ9","hsh":true}]}""");
         setEventMetadata("GRID_FIRSTPAGE","""{"handler":"subgrid_firstpage","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"cmbavOrderedby"},{"av":"AV16OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV11AttractionName","fld":"vATTRACTIONNAME"},{"av":"AV12Update","fld":"vUPDATE"},{"av":"AV13Delete","fld":"vDELETE"},{"av":"AV15CountryName","fld":"vCOUNTRYNAME"},{"av":"AV14ADVANCED_LABEL_TEMPLATE","fld":"vADVANCED_LABEL_TEMPLATE","hsh":true}]""");
         setEventMetadata("GRID_FIRSTPAGE",""","oparms":[{"ctrl":"BTNTOGGLE","prop":"Class"},{"av":"lblLblcountrynamefilter_Caption","ctrl":"LBLCOUNTRYNAMEFILTER","prop":"Caption"}]}""");
         setEventMetadata("GRID_PREVPAGE","""{"handler":"subgrid_previouspage","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"cmbavOrderedby"},{"av":"AV16OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV11AttractionName","fld":"vATTRACTIONNAME"},{"av":"AV12Update","fld":"vUPDATE"},{"av":"AV13Delete","fld":"vDELETE"},{"av":"AV15CountryName","fld":"vCOUNTRYNAME"},{"av":"AV14ADVANCED_LABEL_TEMPLATE","fld":"vADVANCED_LABEL_TEMPLATE","hsh":true}]""");
         setEventMetadata("GRID_PREVPAGE",""","oparms":[{"ctrl":"BTNTOGGLE","prop":"Class"},{"av":"lblLblcountrynamefilter_Caption","ctrl":"LBLCOUNTRYNAMEFILTER","prop":"Caption"}]}""");
         setEventMetadata("GRID_NEXTPAGE","""{"handler":"subgrid_nextpage","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"cmbavOrderedby"},{"av":"AV16OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV11AttractionName","fld":"vATTRACTIONNAME"},{"av":"AV12Update","fld":"vUPDATE"},{"av":"AV13Delete","fld":"vDELETE"},{"av":"AV15CountryName","fld":"vCOUNTRYNAME"},{"av":"AV14ADVANCED_LABEL_TEMPLATE","fld":"vADVANCED_LABEL_TEMPLATE","hsh":true}]""");
         setEventMetadata("GRID_NEXTPAGE",""","oparms":[{"ctrl":"BTNTOGGLE","prop":"Class"},{"av":"lblLblcountrynamefilter_Caption","ctrl":"LBLCOUNTRYNAMEFILTER","prop":"Caption"}]}""");
         setEventMetadata("GRID_LASTPAGE","""{"handler":"subgrid_lastpage","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"cmbavOrderedby"},{"av":"AV16OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV11AttractionName","fld":"vATTRACTIONNAME"},{"av":"AV12Update","fld":"vUPDATE"},{"av":"AV13Delete","fld":"vDELETE"},{"av":"AV15CountryName","fld":"vCOUNTRYNAME"},{"av":"AV14ADVANCED_LABEL_TEMPLATE","fld":"vADVANCED_LABEL_TEMPLATE","hsh":true}]""");
         setEventMetadata("GRID_LASTPAGE",""","oparms":[{"ctrl":"BTNTOGGLE","prop":"Class"},{"av":"lblLblcountrynamefilter_Caption","ctrl":"LBLCOUNTRYNAMEFILTER","prop":"Caption"}]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Delete","iparms":[]}""");
         return  ;
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      public override void initialize( )
      {
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV12Update = "";
         AV13Delete = "";
         AV11AttractionName = "";
         AV15CountryName = "";
         AV14ADVANCED_LABEL_TEMPLATE = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTitletext_Jsonclick = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtninsert_Jsonclick = "";
         bttBtntoggle_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         bttBtntoggleontable_Jsonclick = "";
         lblLblcountrynamefilter_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A8AttractionName = "";
         A10CountryName = "";
         A12CategoryName = "";
         A13AttractionPhoto = "";
         A40000AttractionPhoto_GXI = "";
         A15CityName = "";
         AV17Pgmname = "";
         GridState = new GXGridStateHandler(context,"Grid",GetPgmname(),subgrid_varsfromstate,subgrid_varstostate);
         lV11AttractionName = "";
         lV15CountryName = "";
         H000E2_A14CityId = new short[1] ;
         H000E2_n14CityId = new bool[] {false} ;
         H000E2_A11CategoryId = new short[1] ;
         H000E2_n11CategoryId = new bool[] {false} ;
         H000E2_A9CountryId = new short[1] ;
         H000E2_A15CityName = new string[] {""} ;
         H000E2_A40000AttractionPhoto_GXI = new string[] {""} ;
         H000E2_A12CategoryName = new string[] {""} ;
         H000E2_A10CountryName = new string[] {""} ;
         H000E2_A8AttractionName = new string[] {""} ;
         H000E2_A7AttractionId = new short[1] ;
         H000E2_A13AttractionPhoto = new string[] {""} ;
         H000E3_AGRID_nRecordCount = new long[1] ;
         GridRow = new GXWebRow();
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV7HTTPRequest = new GxHttpRequest( context);
         AV6Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         sImgUrl = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwattractions__default(),
            new Object[][] {
                new Object[] {
               H000E2_A14CityId, H000E2_n14CityId, H000E2_A11CategoryId, H000E2_n11CategoryId, H000E2_A9CountryId, H000E2_A15CityName, H000E2_A40000AttractionPhoto_GXI, H000E2_A12CategoryName, H000E2_A10CountryName, H000E2_A8AttractionName,
               H000E2_A7AttractionId, H000E2_A13AttractionPhoto
               }
               , new Object[] {
               H000E3_AGRID_nRecordCount
               }
            }
         );
         AV17Pgmname = "WWAttractions";
         /* GeneXus formulas. */
         AV17Pgmname = "WWAttractions";
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV16OrderedBy ;
      private short gxajaxcallmode ;
      private short A9CountryId ;
      private short wbEnd ;
      private short wbStart ;
      private short A7AttractionId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short A14CityId ;
      private short A11CategoryId ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int nRC_GXsfl_29 ;
      private int subGrid_Rows ;
      private int nGXsfl_29_idx=1 ;
      private int edtavAttractionname_Enabled ;
      private int edtavCountryname_Visible ;
      private int edtavCountryname_Enabled ;
      private int subGrid_Islastpage ;
      private int edtavUpdate_Enabled ;
      private int edtavDelete_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int GridPageCount ;
      private int edtAttractionId_Enabled ;
      private int edtAttractionName_Enabled ;
      private int edtCountryName_Enabled ;
      private int edtCategoryName_Enabled ;
      private int edtAttractionPhoto_Enabled ;
      private int edtCityName_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string divFilterscontainer_Class ;
      private string divCountrynamefiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_29_idx="0001" ;
      private string AV12Update ;
      private string AV13Delete ;
      private string AV11AttractionName ;
      private string AV15CountryName ;
      private string AV14ADVANCED_LABEL_TEMPLATE ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string divGridcell_Internalname ;
      private string divGridcell_Class ;
      private string divGridtable_Internalname ;
      private string divTabletop_Internalname ;
      private string lblTitletext_Internalname ;
      private string lblTitletext_Jsonclick ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtninsert_Internalname ;
      private string bttBtninsert_Jsonclick ;
      private string edtavAttractionname_Internalname ;
      private string edtavAttractionname_Jsonclick ;
      private string bttBtntoggle_Class ;
      private string bttBtntoggle_Internalname ;
      private string bttBtntoggle_Jsonclick ;
      private string bttBtntoggle_Tooltiptext ;
      private string divGridcontainer_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string divFilterscontainer_Internalname ;
      private string bttBtntoggleontable_Internalname ;
      private string bttBtntoggleontable_Jsonclick ;
      private string cmbavOrderedby_Internalname ;
      private string cmbavOrderedby_Jsonclick ;
      private string divCountrynamefiltercontainer_Internalname ;
      private string lblLblcountrynamefilter_Internalname ;
      private string lblLblcountrynamefilter_Caption ;
      private string lblLblcountrynamefilter_Jsonclick ;
      private string edtavCountryname_Internalname ;
      private string edtavCountryname_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtAttractionId_Internalname ;
      private string A8AttractionName ;
      private string edtAttractionName_Internalname ;
      private string A10CountryName ;
      private string edtCountryName_Internalname ;
      private string A12CategoryName ;
      private string edtCategoryName_Internalname ;
      private string edtAttractionPhoto_Internalname ;
      private string A15CityName ;
      private string edtCityName_Internalname ;
      private string edtavUpdate_Internalname ;
      private string edtavDelete_Internalname ;
      private string AV17Pgmname ;
      private string lV11AttractionName ;
      private string lV15CountryName ;
      private string edtavUpdate_Link ;
      private string edtavDelete_Link ;
      private string edtAttractionName_Link ;
      private string edtCountryName_Link ;
      private string sGXsfl_29_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtAttractionId_Jsonclick ;
      private string edtAttractionName_Jsonclick ;
      private string edtCountryName_Jsonclick ;
      private string edtCategoryName_Jsonclick ;
      private string sImgUrl ;
      private string edtCityName_Jsonclick ;
      private string edtavUpdate_Jsonclick ;
      private string edtavDelete_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_29_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool n14CityId ;
      private bool n11CategoryId ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool A13AttractionPhoto_IsBlob ;
      private string A40000AttractionPhoto_GXI ;
      private string A13AttractionPhoto ;
      private GXWebGrid GridContainer ;
      private GXGridStateHandler GridState ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GxHttpRequest AV7HTTPRequest ;
      private IGxSession AV6Session ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavOrderedby ;
      private IDataStoreProvider pr_default ;
      private short[] H000E2_A14CityId ;
      private bool[] H000E2_n14CityId ;
      private short[] H000E2_A11CategoryId ;
      private bool[] H000E2_n11CategoryId ;
      private short[] H000E2_A9CountryId ;
      private string[] H000E2_A15CityName ;
      private string[] H000E2_A40000AttractionPhoto_GXI ;
      private string[] H000E2_A12CategoryName ;
      private string[] H000E2_A10CountryName ;
      private string[] H000E2_A8AttractionName ;
      private short[] H000E2_A7AttractionId ;
      private string[] H000E2_A13AttractionPhoto ;
      private long[] H000E3_AGRID_nRecordCount ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV9TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wwattractions__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H000E2( IGxContext context ,
                                             string AV11AttractionName ,
                                             string AV15CountryName ,
                                             string A8AttractionName ,
                                             string A10CountryName ,
                                             short AV16OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[5];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.[CityId], T1.[CategoryId], T1.[CountryId], T4.[CityName], T1.[AttractionPhoto_GXI], T2.[CategoryName], T3.[CountryName], T1.[AttractionName], T1.[AttractionId], T1.[AttractionPhoto]";
         sFromString = " FROM ((([Attractions] T1 LEFT JOIN [Category] T2 ON T2.[CategoryId] = T1.[CategoryId]) INNER JOIN [Country] T3 ON T3.[CountryId] = T1.[CountryId]) LEFT JOIN [CountryCity] T4 ON T4.[CountryId] = T1.[CountryId] AND T4.[CityId] = T1.[CityId])";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11AttractionName)) )
         {
            AddWhere(sWhereString, "(T1.[AttractionName] like @lV11AttractionName)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15CountryName)) )
         {
            AddWhere(sWhereString, "(T3.[CountryName] like @lV15CountryName)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV16OrderedBy == 1 )
         {
            sOrderString += " ORDER BY T1.[AttractionName]";
         }
         else if ( AV16OrderedBy == 2 )
         {
            sOrderString += " ORDER BY T3.[CountryName]";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.[AttractionId]";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H000E3( IGxContext context ,
                                             string AV11AttractionName ,
                                             string AV15CountryName ,
                                             string A8AttractionName ,
                                             string A10CountryName ,
                                             short AV16OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[2];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ((([Attractions] T1 LEFT JOIN [Category] T4 ON T4.[CategoryId] = T1.[CategoryId]) INNER JOIN [Country] T2 ON T2.[CountryId] = T1.[CountryId]) LEFT JOIN [CountryCity] T3 ON T3.[CountryId] = T1.[CountryId] AND T3.[CityId] = T1.[CityId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11AttractionName)) )
         {
            AddWhere(sWhereString, "(T1.[AttractionName] like @lV11AttractionName)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15CountryName)) )
         {
            AddWhere(sWhereString, "(T2.[CountryName] like @lV15CountryName)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV16OrderedBy == 1 )
         {
            scmdbuf += "";
         }
         else if ( AV16OrderedBy == 2 )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H000E2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] );
               case 1 :
                     return conditional_H000E3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH000E2;
          prmH000E2 = new Object[] {
          new ParDef("@lV11AttractionName",GXType.NChar,50,0) ,
          new ParDef("@lV15CountryName",GXType.NChar,50,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH000E3;
          prmH000E3 = new Object[] {
          new ParDef("@lV11AttractionName",GXType.NChar,50,0) ,
          new ParDef("@lV15CountryName",GXType.NChar,50,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000E2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000E2,6, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000E3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000E3,1, GxCacheFrequency.OFF ,true,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((short[]) buf[4])[0] = rslt.getShort(3);
                ((string[]) buf[5])[0] = rslt.getString(4, 50);
                ((string[]) buf[6])[0] = rslt.getMultimediaUri(5);
                ((string[]) buf[7])[0] = rslt.getString(6, 50);
                ((string[]) buf[8])[0] = rslt.getString(7, 50);
                ((string[]) buf[9])[0] = rslt.getString(8, 50);
                ((short[]) buf[10])[0] = rslt.getShort(9);
                ((string[]) buf[11])[0] = rslt.getMultimediaFile(10, rslt.getVarchar(5));
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
