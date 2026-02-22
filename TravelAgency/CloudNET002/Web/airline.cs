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
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class airline : GXDataArea
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_2") == 0 )
         {
            A36AirlineId = (short)(Math.Round(NumberUtil.Val( GetPar( "AirlineId"), "."), 18, MidpointRounding.ToEven));
            n36AirlineId = false;
            AssignAttri("", false, "A36AirlineId", StringUtil.LTrimStr( (decimal)(A36AirlineId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_2( A36AirlineId) ;
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
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_10-184260", 0) ;
            }
         }
         Form.Meta.addItem("description", "Airline", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtAirlineId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("TravelAgency", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public airline( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("TravelAgency", true);
      }

      public airline( IGxContext context )
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
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
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

      protected void fix_multi_value_controls( )
      {
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"none\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTitlecontainer_Internalname, 1, 0, "px", 0, "px", "title-container", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Airline", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Airline.htm");
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
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divFormcontainer_Internalname, 1, 0, "px", 0, "px", "form-container", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divToolbarcell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3 form__toolbar-cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "btn-group", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-first";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Airline.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Airline.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Airline.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Airline.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 4, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx0080.aspx"+"',["+"{Ctrl:gx.dom.el('"+"AIRLINEID"+"'), id:'"+"AIRLINEID"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_Airline.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell-advanced", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAirlineId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAirlineId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAirlineId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A36AirlineId), 4, 0, ".", "")), StringUtil.LTrim( ((edtAirlineId_Enabled!=0) ? context.localUtil.Format( (decimal)(A36AirlineId), "ZZZ9") : context.localUtil.Format( (decimal)(A36AirlineId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAirlineId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAirlineId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Airline.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAirlineName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAirlineName_Internalname, "Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAirlineName_Internalname, StringUtil.RTrim( A37AirlineName), StringUtil.RTrim( context.localUtil.Format( A37AirlineName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAirlineName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAirlineName_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Airline.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAirlineDiscountPercentage_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAirlineDiscountPercentage_Internalname, "Discount Percentage", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAirlineDiscountPercentage_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A38AirlineDiscountPercentage), 3, 0, ".", "")), StringUtil.LTrim( ((edtAirlineDiscountPercentage_Enabled!=0) ? context.localUtil.Format( (decimal)(A38AirlineDiscountPercentage), "ZZ9") : context.localUtil.Format( (decimal)(A38AirlineDiscountPercentage), "ZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAirlineDiscountPercentage_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAirlineDiscountPercentage_Enabled, 0, "text", "1", 3, "chr", 1, "row", 3, 0, 0, 0, 0, -1, 0, true, "Percentage", "end", false, "", "HLP_Airline.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAirlineFlightMostExpensiveId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAirlineFlightMostExpensiveId_Internalname, "Expensive Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAirlineFlightMostExpensiveId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A44AirlineFlightMostExpensiveId), 4, 0, ".", "")), StringUtil.LTrim( ((edtAirlineFlightMostExpensiveId_Enabled!=0) ? context.localUtil.Format( (decimal)(A44AirlineFlightMostExpensiveId), "ZZZ9") : context.localUtil.Format( (decimal)(A44AirlineFlightMostExpensiveId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAirlineFlightMostExpensiveId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAirlineFlightMostExpensiveId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Airline.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__actions--fixed", "end", "Middle", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirm", bttBtn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Airline.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Airline.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Airline.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "end", "Middle", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Z36AirlineId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z36AirlineId"), ".", ","), 18, MidpointRounding.ToEven));
            Z37AirlineName = cgiGet( "Z37AirlineName");
            Z38AirlineDiscountPercentage = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z38AirlineDiscountPercentage"), ".", ","), 18, MidpointRounding.ToEven));
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtAirlineId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAirlineId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "AIRLINEID");
               AnyError = 1;
               GX_FocusControl = edtAirlineId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A36AirlineId = 0;
               n36AirlineId = false;
               AssignAttri("", false, "A36AirlineId", StringUtil.LTrimStr( (decimal)(A36AirlineId), 4, 0));
            }
            else
            {
               A36AirlineId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtAirlineId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               n36AirlineId = false;
               AssignAttri("", false, "A36AirlineId", StringUtil.LTrimStr( (decimal)(A36AirlineId), 4, 0));
            }
            A37AirlineName = cgiGet( edtAirlineName_Internalname);
            AssignAttri("", false, "A37AirlineName", A37AirlineName);
            if ( ( ( context.localUtil.CToN( cgiGet( edtAirlineDiscountPercentage_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAirlineDiscountPercentage_Internalname), ".", ",") > Convert.ToDecimal( 999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "AIRLINEDISCOUNTPERCENTAGE");
               AnyError = 1;
               GX_FocusControl = edtAirlineDiscountPercentage_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A38AirlineDiscountPercentage = 0;
               AssignAttri("", false, "A38AirlineDiscountPercentage", StringUtil.LTrimStr( (decimal)(A38AirlineDiscountPercentage), 3, 0));
            }
            else
            {
               A38AirlineDiscountPercentage = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtAirlineDiscountPercentage_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A38AirlineDiscountPercentage", StringUtil.LTrimStr( (decimal)(A38AirlineDiscountPercentage), 3, 0));
            }
            A44AirlineFlightMostExpensiveId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtAirlineFlightMostExpensiveId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
            n44AirlineFlightMostExpensiveId = false;
            AssignAttri("", false, "A44AirlineFlightMostExpensiveId", StringUtil.LTrimStr( (decimal)(A44AirlineFlightMostExpensiveId), 4, 0));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            standaloneNotModal( ) ;
         }
         else
         {
            standaloneNotModal( ) ;
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
            {
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               A36AirlineId = (short)(Math.Round(NumberUtil.Val( GetPar( "AirlineId"), "."), 18, MidpointRounding.ToEven));
               n36AirlineId = false;
               AssignAttri("", false, "A36AirlineId", StringUtil.LTrimStr( (decimal)(A36AirlineId), 4, 0));
               getEqualNoModal( ) ;
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               disable_std_buttons_dsp( ) ;
               standaloneModal( ) ;
            }
            else
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               standaloneModal( ) ;
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
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
                        if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_enter( ) ;
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                        else if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_first( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "PREVIOUS") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_previous( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_next( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_last( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "SELECT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_select( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DELETE") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_delete( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                        {
                           context.wbHandled = 1;
                           AfterKeyLoadScreen( ) ;
                        }
                     }
                     else
                     {
                     }
                  }
                  context.wbHandled = 1;
               }
            }
         }
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll078( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      protected void disable_std_buttons( )
      {
         if ( IsIns( ) )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
      }

      protected void disable_std_buttons_dsp( )
      {
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         bttBtn_first_Visible = 0;
         AssignProp("", false, bttBtn_first_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_first_Visible), 5, 0), true);
         bttBtn_previous_Visible = 0;
         AssignProp("", false, bttBtn_previous_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_previous_Visible), 5, 0), true);
         bttBtn_next_Visible = 0;
         AssignProp("", false, bttBtn_next_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_next_Visible), 5, 0), true);
         bttBtn_last_Visible = 0;
         AssignProp("", false, bttBtn_last_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_last_Visible), 5, 0), true);
         bttBtn_select_Visible = 0;
         AssignProp("", false, bttBtn_select_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_select_Visible), 5, 0), true);
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) )
         {
            bttBtn_enter_Visible = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
         }
         DisableAttributes078( ) ;
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
      }

      protected void ResetCaption070( )
      {
      }

      protected void ZM078( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z37AirlineName = T00073_A37AirlineName[0];
               Z38AirlineDiscountPercentage = T00073_A38AirlineDiscountPercentage[0];
            }
            else
            {
               Z37AirlineName = A37AirlineName;
               Z38AirlineDiscountPercentage = A38AirlineDiscountPercentage;
            }
         }
         if ( GX_JID == -1 )
         {
            Z36AirlineId = A36AirlineId;
            Z37AirlineName = A37AirlineName;
            Z38AirlineDiscountPercentage = A38AirlineDiscountPercentage;
            Z44AirlineFlightMostExpensiveId = A44AirlineFlightMostExpensiveId;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_delete_Enabled = 1;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtn_enter_Enabled = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_enter_Enabled = 1;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
      }

      protected void Load078( )
      {
         /* Using cursor T00079 */
         pr_default.execute(3, new Object[] {n36AirlineId, A36AirlineId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound8 = 1;
            A37AirlineName = T00079_A37AirlineName[0];
            AssignAttri("", false, "A37AirlineName", A37AirlineName);
            A38AirlineDiscountPercentage = T00079_A38AirlineDiscountPercentage[0];
            AssignAttri("", false, "A38AirlineDiscountPercentage", StringUtil.LTrimStr( (decimal)(A38AirlineDiscountPercentage), 3, 0));
            A44AirlineFlightMostExpensiveId = T00079_A44AirlineFlightMostExpensiveId[0];
            n44AirlineFlightMostExpensiveId = T00079_n44AirlineFlightMostExpensiveId[0];
            AssignAttri("", false, "A44AirlineFlightMostExpensiveId", StringUtil.LTrimStr( (decimal)(A44AirlineFlightMostExpensiveId), 4, 0));
            ZM078( -1) ;
         }
         pr_default.close(3);
         OnLoadActions078( ) ;
      }

      protected void OnLoadActions078( )
      {
      }

      protected void CheckExtendedTable078( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00076 */
         pr_default.execute(2, new Object[] {n36AirlineId, A36AirlineId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            A44AirlineFlightMostExpensiveId = T00076_A44AirlineFlightMostExpensiveId[0];
            n44AirlineFlightMostExpensiveId = T00076_n44AirlineFlightMostExpensiveId[0];
            AssignAttri("", false, "A44AirlineFlightMostExpensiveId", StringUtil.LTrimStr( (decimal)(A44AirlineFlightMostExpensiveId), 4, 0));
         }
         else
         {
            A44AirlineFlightMostExpensiveId = 0;
            n44AirlineFlightMostExpensiveId = false;
            AssignAttri("", false, "A44AirlineFlightMostExpensiveId", StringUtil.LTrimStr( (decimal)(A44AirlineFlightMostExpensiveId), 4, 0));
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors078( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( short A36AirlineId )
      {
         /* Using cursor T000712 */
         pr_default.execute(4, new Object[] {n36AirlineId, A36AirlineId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            A44AirlineFlightMostExpensiveId = T000712_A44AirlineFlightMostExpensiveId[0];
            n44AirlineFlightMostExpensiveId = T000712_n44AirlineFlightMostExpensiveId[0];
            AssignAttri("", false, "A44AirlineFlightMostExpensiveId", StringUtil.LTrimStr( (decimal)(A44AirlineFlightMostExpensiveId), 4, 0));
         }
         else
         {
            A44AirlineFlightMostExpensiveId = 0;
            n44AirlineFlightMostExpensiveId = false;
            AssignAttri("", false, "A44AirlineFlightMostExpensiveId", StringUtil.LTrimStr( (decimal)(A44AirlineFlightMostExpensiveId), 4, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A44AirlineFlightMostExpensiveId), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey078( )
      {
         /* Using cursor T000713 */
         pr_default.execute(5, new Object[] {n36AirlineId, A36AirlineId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound8 = 1;
         }
         else
         {
            RcdFound8 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00073 */
         pr_default.execute(1, new Object[] {n36AirlineId, A36AirlineId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM078( 1) ;
            RcdFound8 = 1;
            A36AirlineId = T00073_A36AirlineId[0];
            n36AirlineId = T00073_n36AirlineId[0];
            AssignAttri("", false, "A36AirlineId", StringUtil.LTrimStr( (decimal)(A36AirlineId), 4, 0));
            A37AirlineName = T00073_A37AirlineName[0];
            AssignAttri("", false, "A37AirlineName", A37AirlineName);
            A38AirlineDiscountPercentage = T00073_A38AirlineDiscountPercentage[0];
            AssignAttri("", false, "A38AirlineDiscountPercentage", StringUtil.LTrimStr( (decimal)(A38AirlineDiscountPercentage), 3, 0));
            Z36AirlineId = A36AirlineId;
            sMode8 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load078( ) ;
            if ( AnyError == 1 )
            {
               RcdFound8 = 0;
               InitializeNonKey078( ) ;
            }
            Gx_mode = sMode8;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound8 = 0;
            InitializeNonKey078( ) ;
            sMode8 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode8;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey078( ) ;
         if ( RcdFound8 == 0 )
         {
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound8 = 0;
         /* Using cursor T000714 */
         pr_default.execute(6, new Object[] {n36AirlineId, A36AirlineId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T000714_A36AirlineId[0] < A36AirlineId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T000714_A36AirlineId[0] > A36AirlineId ) ) )
            {
               A36AirlineId = T000714_A36AirlineId[0];
               n36AirlineId = T000714_n36AirlineId[0];
               AssignAttri("", false, "A36AirlineId", StringUtil.LTrimStr( (decimal)(A36AirlineId), 4, 0));
               RcdFound8 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound8 = 0;
         /* Using cursor T000715 */
         pr_default.execute(7, new Object[] {n36AirlineId, A36AirlineId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T000715_A36AirlineId[0] > A36AirlineId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T000715_A36AirlineId[0] < A36AirlineId ) ) )
            {
               A36AirlineId = T000715_A36AirlineId[0];
               n36AirlineId = T000715_n36AirlineId[0];
               AssignAttri("", false, "A36AirlineId", StringUtil.LTrimStr( (decimal)(A36AirlineId), 4, 0));
               RcdFound8 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey078( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtAirlineId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert078( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound8 == 1 )
            {
               if ( A36AirlineId != Z36AirlineId )
               {
                  A36AirlineId = Z36AirlineId;
                  n36AirlineId = false;
                  AssignAttri("", false, "A36AirlineId", StringUtil.LTrimStr( (decimal)(A36AirlineId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "AIRLINEID");
                  AnyError = 1;
                  GX_FocusControl = edtAirlineId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtAirlineId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update078( ) ;
                  GX_FocusControl = edtAirlineId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A36AirlineId != Z36AirlineId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtAirlineId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert078( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "AIRLINEID");
                     AnyError = 1;
                     GX_FocusControl = edtAirlineId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtAirlineId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert078( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      protected void btn_delete( )
      {
         if ( A36AirlineId != Z36AirlineId )
         {
            A36AirlineId = Z36AirlineId;
            n36AirlineId = false;
            AssignAttri("", false, "A36AirlineId", StringUtil.LTrimStr( (decimal)(A36AirlineId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "AIRLINEID");
            AnyError = 1;
            GX_FocusControl = edtAirlineId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtAirlineId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            getByPrimaryKey( ) ;
         }
         CloseCursors();
      }

      protected void btn_get( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         if ( RcdFound8 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "AIRLINEID");
            AnyError = 1;
            GX_FocusControl = edtAirlineId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtAirlineName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart078( ) ;
         if ( RcdFound8 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAirlineName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd078( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_previous( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_previous( ) ;
         if ( RcdFound8 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAirlineName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_next( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_next( ) ;
         if ( RcdFound8 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAirlineName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_last( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart078( ) ;
         if ( RcdFound8 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound8 != 0 )
            {
               ScanNext078( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAirlineName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd078( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency078( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00072 */
            pr_default.execute(0, new Object[] {n36AirlineId, A36AirlineId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Airline"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z37AirlineName, T00072_A37AirlineName[0]) != 0 ) || ( Z38AirlineDiscountPercentage != T00072_A38AirlineDiscountPercentage[0] ) )
            {
               if ( StringUtil.StrCmp(Z37AirlineName, T00072_A37AirlineName[0]) != 0 )
               {
                  GXUtil.WriteLog("airline:[seudo value changed for attri]"+"AirlineName");
                  GXUtil.WriteLogRaw("Old: ",Z37AirlineName);
                  GXUtil.WriteLogRaw("Current: ",T00072_A37AirlineName[0]);
               }
               if ( Z38AirlineDiscountPercentage != T00072_A38AirlineDiscountPercentage[0] )
               {
                  GXUtil.WriteLog("airline:[seudo value changed for attri]"+"AirlineDiscountPercentage");
                  GXUtil.WriteLogRaw("Old: ",Z38AirlineDiscountPercentage);
                  GXUtil.WriteLogRaw("Current: ",T00072_A38AirlineDiscountPercentage[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Airline"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert078( )
      {
         BeforeValidate078( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable078( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM078( 0) ;
            CheckOptimisticConcurrency078( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm078( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert078( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000716 */
                     pr_default.execute(8, new Object[] {A37AirlineName, A38AirlineDiscountPercentage});
                     A36AirlineId = T000716_A36AirlineId[0];
                     n36AirlineId = T000716_n36AirlineId[0];
                     AssignAttri("", false, "A36AirlineId", StringUtil.LTrimStr( (decimal)(A36AirlineId), 4, 0));
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Airline");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption070( ) ;
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load078( ) ;
            }
            EndLevel078( ) ;
         }
         CloseExtendedTableCursors078( ) ;
      }

      protected void Update078( )
      {
         BeforeValidate078( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable078( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency078( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm078( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate078( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000717 */
                     pr_default.execute(9, new Object[] {A37AirlineName, A38AirlineDiscountPercentage, n36AirlineId, A36AirlineId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Airline");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Airline"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate078( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption070( ) ;
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel078( ) ;
         }
         CloseExtendedTableCursors078( ) ;
      }

      protected void DeferredUpdate078( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate078( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency078( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls078( ) ;
            AfterConfirm078( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete078( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000718 */
                  pr_default.execute(10, new Object[] {n36AirlineId, A36AirlineId});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("Airline");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound8 == 0 )
                        {
                           InitAll078( ) ;
                           Gx_mode = "INS";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        else
                        {
                           getByPrimaryKey( ) ;
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                        ResetCaption070( ) ;
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode8 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel078( ) ;
         Gx_mode = sMode8;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls078( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000721 */
            pr_default.execute(11, new Object[] {n36AirlineId, A36AirlineId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               A44AirlineFlightMostExpensiveId = T000721_A44AirlineFlightMostExpensiveId[0];
               n44AirlineFlightMostExpensiveId = T000721_n44AirlineFlightMostExpensiveId[0];
               AssignAttri("", false, "A44AirlineFlightMostExpensiveId", StringUtil.LTrimStr( (decimal)(A44AirlineFlightMostExpensiveId), 4, 0));
            }
            else
            {
               A44AirlineFlightMostExpensiveId = 0;
               n44AirlineFlightMostExpensiveId = false;
               AssignAttri("", false, "A44AirlineFlightMostExpensiveId", StringUtil.LTrimStr( (decimal)(A44AirlineFlightMostExpensiveId), 4, 0));
            }
            pr_default.close(11);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000722 */
            pr_default.execute(12, new Object[] {n36AirlineId, A36AirlineId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Flight"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
         }
      }

      protected void EndLevel078( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete078( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(11);
            context.CommitDataStores("airline",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues070( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(11);
            context.RollbackDataStores("airline",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart078( )
      {
         /* Using cursor T000723 */
         pr_default.execute(13);
         RcdFound8 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound8 = 1;
            A36AirlineId = T000723_A36AirlineId[0];
            n36AirlineId = T000723_n36AirlineId[0];
            AssignAttri("", false, "A36AirlineId", StringUtil.LTrimStr( (decimal)(A36AirlineId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext078( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound8 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound8 = 1;
            A36AirlineId = T000723_A36AirlineId[0];
            n36AirlineId = T000723_n36AirlineId[0];
            AssignAttri("", false, "A36AirlineId", StringUtil.LTrimStr( (decimal)(A36AirlineId), 4, 0));
         }
      }

      protected void ScanEnd078( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm078( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert078( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate078( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete078( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete078( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate078( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes078( )
      {
         edtAirlineId_Enabled = 0;
         AssignProp("", false, edtAirlineId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAirlineId_Enabled), 5, 0), true);
         edtAirlineName_Enabled = 0;
         AssignProp("", false, edtAirlineName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAirlineName_Enabled), 5, 0), true);
         edtAirlineDiscountPercentage_Enabled = 0;
         AssignProp("", false, edtAirlineDiscountPercentage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAirlineDiscountPercentage_Enabled), 5, 0), true);
         edtAirlineFlightMostExpensiveId_Enabled = 0;
         AssignProp("", false, edtAirlineFlightMostExpensiveId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAirlineFlightMostExpensiveId_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes078( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues070( )
      {
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
         MasterPageObj.master_styles();
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
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         if ( StringUtil.StrCmp(context.GetLanguageProperty( "rtl"), "true") == 0 )
         {
            context.WriteHtmlText( " dir=\"rtl\" ") ;
         }
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("airline.aspx") +"\">") ;
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z36AirlineId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z36AirlineId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z37AirlineName", StringUtil.RTrim( Z37AirlineName));
         GxWebStd.gx_hidden_field( context, "Z38AirlineDiscountPercentage", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z38AirlineDiscountPercentage), 3, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken(sPrefix);
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

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
         context.WriteHtmlText( ">") ;
         Draw( ) ;
         context.WriteHtmlText( "</div>") ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("airline.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Airline" ;
      }

      public override string GetPgmdesc( )
      {
         return "Airline" ;
      }

      protected void InitializeNonKey078( )
      {
         A44AirlineFlightMostExpensiveId = 0;
         n44AirlineFlightMostExpensiveId = false;
         AssignAttri("", false, "A44AirlineFlightMostExpensiveId", StringUtil.LTrimStr( (decimal)(A44AirlineFlightMostExpensiveId), 4, 0));
         A37AirlineName = "";
         AssignAttri("", false, "A37AirlineName", A37AirlineName);
         A38AirlineDiscountPercentage = 0;
         AssignAttri("", false, "A38AirlineDiscountPercentage", StringUtil.LTrimStr( (decimal)(A38AirlineDiscountPercentage), 3, 0));
         Z37AirlineName = "";
         Z38AirlineDiscountPercentage = 0;
      }

      protected void InitAll078( )
      {
         A36AirlineId = 0;
         n36AirlineId = false;
         AssignAttri("", false, "A36AirlineId", StringUtil.LTrimStr( (decimal)(A36AirlineId), 4, 0));
         InitializeNonKey078( ) ;
      }

      protected void StandaloneModalInsert( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202622210164023", true, true);
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
         context.AddJavascriptSource("airline.js", "?202622210164023", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainer_Internalname = "TITLECONTAINER";
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         divToolbarcell_Internalname = "TOOLBARCELL";
         edtAirlineId_Internalname = "AIRLINEID";
         edtAirlineName_Internalname = "AIRLINENAME";
         edtAirlineDiscountPercentage_Internalname = "AIRLINEDISCOUNTPERCENTAGE";
         edtAirlineFlightMostExpensiveId_Internalname = "AIRLINEFLIGHTMOSTEXPENSIVEID";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("TravelAgency", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Airline";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtAirlineFlightMostExpensiveId_Jsonclick = "";
         edtAirlineFlightMostExpensiveId_Enabled = 0;
         edtAirlineDiscountPercentage_Jsonclick = "";
         edtAirlineDiscountPercentage_Enabled = 1;
         edtAirlineName_Jsonclick = "";
         edtAirlineName_Enabled = 1;
         edtAirlineId_Jsonclick = "";
         edtAirlineId_Enabled = 1;
         bttBtn_select_Visible = 1;
         bttBtn_last_Visible = 1;
         bttBtn_next_Visible = 1;
         bttBtn_previous_Visible = 1;
         bttBtn_first_Visible = 1;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtAirlineName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
         /* End function AfterKeyLoadScreen */
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void Valid_Airlineid( )
      {
         n36AirlineId = false;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         /* Using cursor T000721 */
         pr_default.execute(11, new Object[] {n36AirlineId, A36AirlineId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            A44AirlineFlightMostExpensiveId = T000721_A44AirlineFlightMostExpensiveId[0];
            n44AirlineFlightMostExpensiveId = T000721_n44AirlineFlightMostExpensiveId[0];
         }
         else
         {
            A44AirlineFlightMostExpensiveId = 0;
            n44AirlineFlightMostExpensiveId = false;
         }
         pr_default.close(11);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A37AirlineName", StringUtil.RTrim( A37AirlineName));
         AssignAttri("", false, "A38AirlineDiscountPercentage", StringUtil.LTrim( StringUtil.NToC( (decimal)(A38AirlineDiscountPercentage), 3, 0, ".", "")));
         AssignAttri("", false, "A44AirlineFlightMostExpensiveId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A44AirlineFlightMostExpensiveId), 4, 0, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z36AirlineId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z36AirlineId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z37AirlineName", StringUtil.RTrim( Z37AirlineName));
         GxWebStd.gx_hidden_field( context, "Z38AirlineDiscountPercentage", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z38AirlineDiscountPercentage), 3, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z44AirlineFlightMostExpensiveId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z44AirlineFlightMostExpensiveId), 4, 0, ".", "")));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[]}""");
         setEventMetadata("VALID_AIRLINEID","""{"handler":"Valid_Airlineid","iparms":[{"av":"A36AirlineId","fld":"AIRLINEID","pic":"ZZZ9"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"}]""");
         setEventMetadata("VALID_AIRLINEID",""","oparms":[{"av":"A37AirlineName","fld":"AIRLINENAME"},{"av":"A38AirlineDiscountPercentage","fld":"AIRLINEDISCOUNTPERCENTAGE","pic":"ZZ9"},{"av":"A44AirlineFlightMostExpensiveId","fld":"AIRLINEFLIGHTMOSTEXPENSIVEID","pic":"ZZZ9"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"Z36AirlineId"},{"av":"Z37AirlineName"},{"av":"Z38AirlineDiscountPercentage"},{"av":"Z44AirlineFlightMostExpensiveId"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"}]}""");
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

      protected override void CloseCursors( )
      {
         pr_default.close(1);
         pr_default.close(11);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z37AirlineName = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A37AirlineName = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gx_mode = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         T00079_A36AirlineId = new short[1] ;
         T00079_n36AirlineId = new bool[] {false} ;
         T00079_A37AirlineName = new string[] {""} ;
         T00079_A38AirlineDiscountPercentage = new short[1] ;
         T00079_A44AirlineFlightMostExpensiveId = new short[1] ;
         T00079_n44AirlineFlightMostExpensiveId = new bool[] {false} ;
         T00076_A44AirlineFlightMostExpensiveId = new short[1] ;
         T00076_n44AirlineFlightMostExpensiveId = new bool[] {false} ;
         T000712_A44AirlineFlightMostExpensiveId = new short[1] ;
         T000712_n44AirlineFlightMostExpensiveId = new bool[] {false} ;
         T000713_A36AirlineId = new short[1] ;
         T000713_n36AirlineId = new bool[] {false} ;
         T00073_A36AirlineId = new short[1] ;
         T00073_n36AirlineId = new bool[] {false} ;
         T00073_A37AirlineName = new string[] {""} ;
         T00073_A38AirlineDiscountPercentage = new short[1] ;
         sMode8 = "";
         T000714_A36AirlineId = new short[1] ;
         T000714_n36AirlineId = new bool[] {false} ;
         T000715_A36AirlineId = new short[1] ;
         T000715_n36AirlineId = new bool[] {false} ;
         T00072_A36AirlineId = new short[1] ;
         T00072_n36AirlineId = new bool[] {false} ;
         T00072_A37AirlineName = new string[] {""} ;
         T00072_A38AirlineDiscountPercentage = new short[1] ;
         T000716_A36AirlineId = new short[1] ;
         T000716_n36AirlineId = new bool[] {false} ;
         T000721_A44AirlineFlightMostExpensiveId = new short[1] ;
         T000721_n44AirlineFlightMostExpensiveId = new bool[] {false} ;
         T000722_A20FlightId = new short[1] ;
         T000723_A36AirlineId = new short[1] ;
         T000723_n36AirlineId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ37AirlineName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.airline__default(),
            new Object[][] {
                new Object[] {
               T00072_A36AirlineId, T00072_A37AirlineName, T00072_A38AirlineDiscountPercentage
               }
               , new Object[] {
               T00073_A36AirlineId, T00073_A37AirlineName, T00073_A38AirlineDiscountPercentage
               }
               , new Object[] {
               T00076_A44AirlineFlightMostExpensiveId, T00076_n44AirlineFlightMostExpensiveId
               }
               , new Object[] {
               T00079_A36AirlineId, T00079_A37AirlineName, T00079_A38AirlineDiscountPercentage, T00079_A44AirlineFlightMostExpensiveId, T00079_n44AirlineFlightMostExpensiveId
               }
               , new Object[] {
               T000712_A44AirlineFlightMostExpensiveId, T000712_n44AirlineFlightMostExpensiveId
               }
               , new Object[] {
               T000713_A36AirlineId
               }
               , new Object[] {
               T000714_A36AirlineId
               }
               , new Object[] {
               T000715_A36AirlineId
               }
               , new Object[] {
               T000716_A36AirlineId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000721_A44AirlineFlightMostExpensiveId, T000721_n44AirlineFlightMostExpensiveId
               }
               , new Object[] {
               T000722_A20FlightId
               }
               , new Object[] {
               T000723_A36AirlineId
               }
            }
         );
      }

      private short Z36AirlineId ;
      private short Z38AirlineDiscountPercentage ;
      private short GxWebError ;
      private short A36AirlineId ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A38AirlineDiscountPercentage ;
      private short A44AirlineFlightMostExpensiveId ;
      private short Z44AirlineFlightMostExpensiveId ;
      private short RcdFound8 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ36AirlineId ;
      private short ZZ38AirlineDiscountPercentage ;
      private short ZZ44AirlineFlightMostExpensiveId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtAirlineId_Enabled ;
      private int edtAirlineName_Enabled ;
      private int edtAirlineDiscountPercentage_Enabled ;
      private int edtAirlineFlightMostExpensiveId_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private string sPrefix ;
      private string Z37AirlineName ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtAirlineId_Internalname ;
      private string divMaintable_Internalname ;
      private string divTitlecontainer_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divFormcontainer_Internalname ;
      private string divToolbarcell_Internalname ;
      private string TempTags ;
      private string bttBtn_first_Internalname ;
      private string bttBtn_first_Jsonclick ;
      private string bttBtn_previous_Internalname ;
      private string bttBtn_previous_Jsonclick ;
      private string bttBtn_next_Internalname ;
      private string bttBtn_next_Jsonclick ;
      private string bttBtn_last_Internalname ;
      private string bttBtn_last_Jsonclick ;
      private string bttBtn_select_Internalname ;
      private string bttBtn_select_Jsonclick ;
      private string edtAirlineId_Jsonclick ;
      private string edtAirlineName_Internalname ;
      private string A37AirlineName ;
      private string edtAirlineName_Jsonclick ;
      private string edtAirlineDiscountPercentage_Internalname ;
      private string edtAirlineDiscountPercentage_Jsonclick ;
      private string edtAirlineFlightMostExpensiveId_Internalname ;
      private string edtAirlineFlightMostExpensiveId_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string Gx_mode ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode8 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ37AirlineName ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n36AirlineId ;
      private bool wbErr ;
      private bool n44AirlineFlightMostExpensiveId ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] T00079_A36AirlineId ;
      private bool[] T00079_n36AirlineId ;
      private string[] T00079_A37AirlineName ;
      private short[] T00079_A38AirlineDiscountPercentage ;
      private short[] T00079_A44AirlineFlightMostExpensiveId ;
      private bool[] T00079_n44AirlineFlightMostExpensiveId ;
      private short[] T00076_A44AirlineFlightMostExpensiveId ;
      private bool[] T00076_n44AirlineFlightMostExpensiveId ;
      private short[] T000712_A44AirlineFlightMostExpensiveId ;
      private bool[] T000712_n44AirlineFlightMostExpensiveId ;
      private short[] T000713_A36AirlineId ;
      private bool[] T000713_n36AirlineId ;
      private short[] T00073_A36AirlineId ;
      private bool[] T00073_n36AirlineId ;
      private string[] T00073_A37AirlineName ;
      private short[] T00073_A38AirlineDiscountPercentage ;
      private short[] T000714_A36AirlineId ;
      private bool[] T000714_n36AirlineId ;
      private short[] T000715_A36AirlineId ;
      private bool[] T000715_n36AirlineId ;
      private short[] T00072_A36AirlineId ;
      private bool[] T00072_n36AirlineId ;
      private string[] T00072_A37AirlineName ;
      private short[] T00072_A38AirlineDiscountPercentage ;
      private short[] T000716_A36AirlineId ;
      private bool[] T000716_n36AirlineId ;
      private short[] T000721_A44AirlineFlightMostExpensiveId ;
      private bool[] T000721_n44AirlineFlightMostExpensiveId ;
      private short[] T000722_A20FlightId ;
      private short[] T000723_A36AirlineId ;
      private bool[] T000723_n36AirlineId ;
   }

   public class airline__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new UpdateCursor(def[9])
         ,new UpdateCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00072;
          prmT00072 = new Object[] {
          new ParDef("@AirlineId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT00073;
          prmT00073 = new Object[] {
          new ParDef("@AirlineId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT00076;
          prmT00076 = new Object[] {
          new ParDef("@AirlineId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT00079;
          prmT00079 = new Object[] {
          new ParDef("@AirlineId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000712;
          prmT000712 = new Object[] {
          new ParDef("@AirlineId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000713;
          prmT000713 = new Object[] {
          new ParDef("@AirlineId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000714;
          prmT000714 = new Object[] {
          new ParDef("@AirlineId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000715;
          prmT000715 = new Object[] {
          new ParDef("@AirlineId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000716;
          prmT000716 = new Object[] {
          new ParDef("@AirlineName",GXType.NChar,50,0) ,
          new ParDef("@AirlineDiscountPercentage",GXType.Int16,3,0)
          };
          Object[] prmT000717;
          prmT000717 = new Object[] {
          new ParDef("@AirlineName",GXType.NChar,50,0) ,
          new ParDef("@AirlineDiscountPercentage",GXType.Int16,3,0) ,
          new ParDef("@AirlineId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000718;
          prmT000718 = new Object[] {
          new ParDef("@AirlineId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000721;
          prmT000721 = new Object[] {
          new ParDef("@AirlineId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000722;
          prmT000722 = new Object[] {
          new ParDef("@AirlineId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000723;
          prmT000723 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T00072", "SELECT [AirlineId], [AirlineName], [AirlineDiscountPercentage] FROM [Airline] WITH (UPDLOCK) WHERE [AirlineId] = @AirlineId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00072,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00073", "SELECT [AirlineId], [AirlineName], [AirlineDiscountPercentage] FROM [Airline] WHERE [AirlineId] = @AirlineId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00073,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00076", "SELECT COALESCE( T1.[AirlineFlightMostExpensiveId], 0) AS AirlineFlightMostExpensiveId FROM (SELECT MIN(T2.[FlightId]) AS AirlineFlightMostExpensiveId, T2.[AirlineId] FROM (([Flight] T2 LEFT JOIN (SELECT MAX(CASE  WHEN COALESCE( T6.[AirlineDiscountPercentage], 0) > T5.[FlightDiscountPercentage] THEN T5.[FlightPrice] * CAST(( 1 - CAST(COALESCE( T6.[AirlineDiscountPercentage], 0) AS decimal( 13, 10)) / 100) AS decimal( 19, 10)) ELSE T5.[FlightPrice] * CAST(( 1 - CAST(T5.[FlightDiscountPercentage] AS decimal( 13, 10)) / 100) AS decimal( 19, 10)) END) AS GXC1, T5.[AirlineId] FROM ([Flight] T5 LEFT JOIN [Airline] T6 WITH (UPDLOCK) ON T6.[AirlineId] = T5.[AirlineId]) GROUP BY T5.[AirlineId] ) T3 ON T3.[AirlineId] = T2.[AirlineId]) LEFT JOIN [Airline] T4 WITH (UPDLOCK) ON T4.[AirlineId] = T2.[AirlineId]) WHERE CASE  WHEN COALESCE( T4.[AirlineDiscountPercentage], 0) > T2.[FlightDiscountPercentage] THEN T2.[FlightPrice] * CAST(( 1 - CAST(COALESCE( T4.[AirlineDiscountPercentage], 0) AS decimal( 13, 10)) / 100) AS decimal( 19, 10)) ELSE T2.[FlightPrice] * CAST(( 1 - CAST(T2.[FlightDiscountPercentage] AS decimal( 13, 10)) / 100) AS decimal( 19, 10)) END = T3.[GXC1] GROUP BY T2.[AirlineId] ) T1 WHERE T1.[AirlineId] = @AirlineId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00076,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00079", "SELECT TM1.[AirlineId], TM1.[AirlineName], TM1.[AirlineDiscountPercentage], COALESCE( T2.[AirlineFlightMostExpensiveId], 0) AS AirlineFlightMostExpensiveId FROM ([Airline] TM1 LEFT JOIN (SELECT MIN(T3.[FlightId]) AS AirlineFlightMostExpensiveId, T3.[AirlineId] FROM (([Flight] T3 LEFT JOIN (SELECT MAX(CASE  WHEN COALESCE( TM1.[AirlineDiscountPercentage], 0) > T6.[FlightDiscountPercentage] THEN T6.[FlightPrice] * CAST(( 1 - CAST(COALESCE( TM1.[AirlineDiscountPercentage], 0) AS decimal( 13, 10)) / 100) AS decimal( 19, 10)) ELSE T6.[FlightPrice] * CAST(( 1 - CAST(T6.[FlightDiscountPercentage] AS decimal( 13, 10)) / 100) AS decimal( 19, 10)) END) AS GXC1, T6.[AirlineId] FROM ([Flight] T6 LEFT JOIN [Airline] TM1 ON TM1.[AirlineId] = T6.[AirlineId]) GROUP BY T6.[AirlineId] ) T4 ON T4.[AirlineId] = T3.[AirlineId]) LEFT JOIN [Airline] TM1 ON TM1.[AirlineId] = T3.[AirlineId]) WHERE CASE  WHEN COALESCE( TM1.[AirlineDiscountPercentage], 0) > T3.[FlightDiscountPercentage] THEN T3.[FlightPrice] * CAST(( 1 - CAST(COALESCE( TM1.[AirlineDiscountPercentage], 0) AS decimal( 13, 10)) / 100) AS decimal( 19, 10)) ELSE T3.[FlightPrice] * CAST(( 1 - CAST(T3.[FlightDiscountPercentage] AS decimal( 13, 10)) / 100) AS decimal( 19, 10)) END = T4.[GXC1] GROUP BY T3.[AirlineId] ) T2 ON T2.[AirlineId] = TM1.[AirlineId]) WHERE TM1.[AirlineId] = @AirlineId ORDER BY TM1.[AirlineId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00079,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000712", "SELECT COALESCE( T1.[AirlineFlightMostExpensiveId], 0) AS AirlineFlightMostExpensiveId FROM (SELECT MIN(T2.[FlightId]) AS AirlineFlightMostExpensiveId, T2.[AirlineId] FROM (([Flight] T2 LEFT JOIN (SELECT MAX(CASE  WHEN COALESCE( T6.[AirlineDiscountPercentage], 0) > T5.[FlightDiscountPercentage] THEN T5.[FlightPrice] * CAST(( 1 - CAST(COALESCE( T6.[AirlineDiscountPercentage], 0) AS decimal( 13, 10)) / 100) AS decimal( 19, 10)) ELSE T5.[FlightPrice] * CAST(( 1 - CAST(T5.[FlightDiscountPercentage] AS decimal( 13, 10)) / 100) AS decimal( 19, 10)) END) AS GXC1, T5.[AirlineId] FROM ([Flight] T5 LEFT JOIN [Airline] T6 WITH (UPDLOCK) ON T6.[AirlineId] = T5.[AirlineId]) GROUP BY T5.[AirlineId] ) T3 ON T3.[AirlineId] = T2.[AirlineId]) LEFT JOIN [Airline] T4 WITH (UPDLOCK) ON T4.[AirlineId] = T2.[AirlineId]) WHERE CASE  WHEN COALESCE( T4.[AirlineDiscountPercentage], 0) > T2.[FlightDiscountPercentage] THEN T2.[FlightPrice] * CAST(( 1 - CAST(COALESCE( T4.[AirlineDiscountPercentage], 0) AS decimal( 13, 10)) / 100) AS decimal( 19, 10)) ELSE T2.[FlightPrice] * CAST(( 1 - CAST(T2.[FlightDiscountPercentage] AS decimal( 13, 10)) / 100) AS decimal( 19, 10)) END = T3.[GXC1] GROUP BY T2.[AirlineId] ) T1 WHERE T1.[AirlineId] = @AirlineId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000712,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000713", "SELECT [AirlineId] FROM [Airline] WHERE [AirlineId] = @AirlineId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000713,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000714", "SELECT TOP 1 [AirlineId] FROM [Airline] WHERE ( [AirlineId] > @AirlineId) ORDER BY [AirlineId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000714,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000715", "SELECT TOP 1 [AirlineId] FROM [Airline] WHERE ( [AirlineId] < @AirlineId) ORDER BY [AirlineId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000715,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000716", "INSERT INTO [Airline]([AirlineName], [AirlineDiscountPercentage]) VALUES(@AirlineName, @AirlineDiscountPercentage); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000716,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000717", "UPDATE [Airline] SET [AirlineName]=@AirlineName, [AirlineDiscountPercentage]=@AirlineDiscountPercentage  WHERE [AirlineId] = @AirlineId", GxErrorMask.GX_NOMASK,prmT000717)
             ,new CursorDef("T000718", "DELETE FROM [Airline]  WHERE [AirlineId] = @AirlineId", GxErrorMask.GX_NOMASK,prmT000718)
             ,new CursorDef("T000721", "SELECT COALESCE( T1.[AirlineFlightMostExpensiveId], 0) AS AirlineFlightMostExpensiveId FROM (SELECT MIN(T2.[FlightId]) AS AirlineFlightMostExpensiveId, T2.[AirlineId] FROM (([Flight] T2 LEFT JOIN (SELECT MAX(CASE  WHEN COALESCE( T6.[AirlineDiscountPercentage], 0) > T5.[FlightDiscountPercentage] THEN T5.[FlightPrice] * CAST(( 1 - CAST(COALESCE( T6.[AirlineDiscountPercentage], 0) AS decimal( 13, 10)) / 100) AS decimal( 19, 10)) ELSE T5.[FlightPrice] * CAST(( 1 - CAST(T5.[FlightDiscountPercentage] AS decimal( 13, 10)) / 100) AS decimal( 19, 10)) END) AS GXC1, T5.[AirlineId] FROM ([Flight] T5 LEFT JOIN [Airline] T6 WITH (UPDLOCK) ON T6.[AirlineId] = T5.[AirlineId]) GROUP BY T5.[AirlineId] ) T3 ON T3.[AirlineId] = T2.[AirlineId]) LEFT JOIN [Airline] T4 WITH (UPDLOCK) ON T4.[AirlineId] = T2.[AirlineId]) WHERE CASE  WHEN COALESCE( T4.[AirlineDiscountPercentage], 0) > T2.[FlightDiscountPercentage] THEN T2.[FlightPrice] * CAST(( 1 - CAST(COALESCE( T4.[AirlineDiscountPercentage], 0) AS decimal( 13, 10)) / 100) AS decimal( 19, 10)) ELSE T2.[FlightPrice] * CAST(( 1 - CAST(T2.[FlightDiscountPercentage] AS decimal( 13, 10)) / 100) AS decimal( 19, 10)) END = T3.[GXC1] GROUP BY T2.[AirlineId] ) T1 WHERE T1.[AirlineId] = @AirlineId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000721,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000722", "SELECT TOP 1 [FlightId] FROM [Flight] WHERE [AirlineId] = @AirlineId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000722,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000723", "SELECT [AirlineId] FROM [Airline] ORDER BY [AirlineId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000723,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 11 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 13 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
