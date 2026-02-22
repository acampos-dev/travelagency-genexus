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
   public class flight : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_14") == 0 )
         {
            A20FlightId = (short)(Math.Round(NumberUtil.Val( GetPar( "FlightId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A20FlightId", StringUtil.LTrimStr( (decimal)(A20FlightId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_14( A20FlightId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_8") == 0 )
         {
            A21FlightDepartureAirportId = (short)(Math.Round(NumberUtil.Val( GetPar( "FlightDepartureAirportId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A21FlightDepartureAirportId", StringUtil.LTrimStr( (decimal)(A21FlightDepartureAirportId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_8( A21FlightDepartureAirportId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_10") == 0 )
         {
            A25FlightDepartureCountryId = (short)(Math.Round(NumberUtil.Val( GetPar( "FlightDepartureCountryId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A25FlightDepartureCountryId", StringUtil.LTrimStr( (decimal)(A25FlightDepartureCountryId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_10( A25FlightDepartureCountryId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_11") == 0 )
         {
            A25FlightDepartureCountryId = (short)(Math.Round(NumberUtil.Val( GetPar( "FlightDepartureCountryId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A25FlightDepartureCountryId", StringUtil.LTrimStr( (decimal)(A25FlightDepartureCountryId), 4, 0));
            A27FlightDepartureCityId = (short)(Math.Round(NumberUtil.Val( GetPar( "FlightDepartureCityId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A27FlightDepartureCityId", StringUtil.LTrimStr( (decimal)(A27FlightDepartureCityId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_11( A25FlightDepartureCountryId, A27FlightDepartureCityId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_9") == 0 )
         {
            A23FlightArrivalAirportId = (short)(Math.Round(NumberUtil.Val( GetPar( "FlightArrivalAirportId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A23FlightArrivalAirportId", StringUtil.LTrimStr( (decimal)(A23FlightArrivalAirportId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_9( A23FlightArrivalAirportId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_12") == 0 )
         {
            A29FlightArrivalCountryId = (short)(Math.Round(NumberUtil.Val( GetPar( "FlightArrivalCountryId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A29FlightArrivalCountryId", StringUtil.LTrimStr( (decimal)(A29FlightArrivalCountryId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_12( A29FlightArrivalCountryId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_13") == 0 )
         {
            A29FlightArrivalCountryId = (short)(Math.Round(NumberUtil.Val( GetPar( "FlightArrivalCountryId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A29FlightArrivalCountryId", StringUtil.LTrimStr( (decimal)(A29FlightArrivalCountryId), 4, 0));
            A31FlightArrivalCityId = (short)(Math.Round(NumberUtil.Val( GetPar( "FlightArrivalCityId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A31FlightArrivalCityId", StringUtil.LTrimStr( (decimal)(A31FlightArrivalCityId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_13( A29FlightArrivalCountryId, A31FlightArrivalCityId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_7") == 0 )
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
            gxLoad_7( A36AirlineId) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridflight_seat") == 0 )
         {
            gxnrGridflight_seat_newrow_invoke( ) ;
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
         Form.Meta.addItem("description", "Flight", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtFlightId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("TravelAgency", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridflight_seat_newrow_invoke( )
      {
         nRC_GXsfl_138 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_138"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_138_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_138_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_138_idx = GetPar( "sGXsfl_138_idx");
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridflight_seat_newrow( ) ;
         /* End function gxnrGridflight_seat_newrow_invoke */
      }

      public flight( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("TravelAgency", true);
      }

      public flight( IGxContext context )
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
         cmbFlightSeatChar = new GXCombobox();
         cmbFlightSeatLocation = new GXCombobox();
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Flight", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Flight.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Flight.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Flight.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Flight.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Flight.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 4, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx0070.aspx"+"',["+"{Ctrl:gx.dom.el('"+"FLIGHTID"+"'), id:'"+"FLIGHTID"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_Flight.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtFlightId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFlightId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFlightId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A20FlightId), 4, 0, ".", "")), StringUtil.LTrim( ((edtFlightId_Enabled!=0) ? context.localUtil.Format( (decimal)(A20FlightId), "ZZZ9") : context.localUtil.Format( (decimal)(A20FlightId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFlightId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFlightId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Flight.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtFlightDepartureAirportId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFlightDepartureAirportId_Internalname, "DepartureAirport id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFlightDepartureAirportId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A21FlightDepartureAirportId), 4, 0, ".", "")), StringUtil.LTrim( ((edtFlightDepartureAirportId_Enabled!=0) ? context.localUtil.Format( (decimal)(A21FlightDepartureAirportId), "ZZZ9") : context.localUtil.Format( (decimal)(A21FlightDepartureAirportId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFlightDepartureAirportId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFlightDepartureAirportId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Flight.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_21_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_21_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_21_Internalname, sImgUrl, imgprompt_21_Link, "", "", context.GetTheme( ), imgprompt_21_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Flight.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtFlightDepartureAirportName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFlightDepartureAirportName_Internalname, "Airport Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFlightDepartureAirportName_Internalname, StringUtil.RTrim( A22FlightDepartureAirportName), StringUtil.RTrim( context.localUtil.Format( A22FlightDepartureAirportName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFlightDepartureAirportName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFlightDepartureAirportName_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Flight.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtFlightDepartureCountryId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFlightDepartureCountryId_Internalname, "DepartureCountry Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFlightDepartureCountryId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A25FlightDepartureCountryId), 4, 0, ".", "")), StringUtil.LTrim( ((edtFlightDepartureCountryId_Enabled!=0) ? context.localUtil.Format( (decimal)(A25FlightDepartureCountryId), "ZZZ9") : context.localUtil.Format( (decimal)(A25FlightDepartureCountryId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFlightDepartureCountryId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFlightDepartureCountryId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Flight.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtFlightDepartureCountryName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFlightDepartureCountryName_Internalname, "DepartureCountry Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFlightDepartureCountryName_Internalname, StringUtil.RTrim( A26FlightDepartureCountryName), StringUtil.RTrim( context.localUtil.Format( A26FlightDepartureCountryName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFlightDepartureCountryName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFlightDepartureCountryName_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Flight.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtFlightDepartureCityId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFlightDepartureCityId_Internalname, "DepartureCity Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFlightDepartureCityId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A27FlightDepartureCityId), 4, 0, ".", "")), StringUtil.LTrim( ((edtFlightDepartureCityId_Enabled!=0) ? context.localUtil.Format( (decimal)(A27FlightDepartureCityId), "ZZZ9") : context.localUtil.Format( (decimal)(A27FlightDepartureCityId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFlightDepartureCityId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFlightDepartureCityId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Flight.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtFlightDepartureCityName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFlightDepartureCityName_Internalname, "DepartureCity Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFlightDepartureCityName_Internalname, StringUtil.RTrim( A28FlightDepartureCityName), StringUtil.RTrim( context.localUtil.Format( A28FlightDepartureCityName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFlightDepartureCityName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFlightDepartureCityName_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Flight.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtFlightArrivalAirportId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFlightArrivalAirportId_Internalname, "ArrivalAirport Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFlightArrivalAirportId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A23FlightArrivalAirportId), 4, 0, ".", "")), StringUtil.LTrim( ((edtFlightArrivalAirportId_Enabled!=0) ? context.localUtil.Format( (decimal)(A23FlightArrivalAirportId), "ZZZ9") : context.localUtil.Format( (decimal)(A23FlightArrivalAirportId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFlightArrivalAirportId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFlightArrivalAirportId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Flight.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_23_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_23_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_23_Internalname, sImgUrl, imgprompt_23_Link, "", "", context.GetTheme( ), imgprompt_23_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Flight.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtFlightArrivalAirportName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFlightArrivalAirportName_Internalname, "ArrivalAirport Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFlightArrivalAirportName_Internalname, StringUtil.RTrim( A24FlightArrivalAirportName), StringUtil.RTrim( context.localUtil.Format( A24FlightArrivalAirportName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFlightArrivalAirportName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFlightArrivalAirportName_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Flight.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtFlightArrivalCountryId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFlightArrivalCountryId_Internalname, "ArrivalCountry Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFlightArrivalCountryId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A29FlightArrivalCountryId), 4, 0, ".", "")), StringUtil.LTrim( ((edtFlightArrivalCountryId_Enabled!=0) ? context.localUtil.Format( (decimal)(A29FlightArrivalCountryId), "ZZZ9") : context.localUtil.Format( (decimal)(A29FlightArrivalCountryId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFlightArrivalCountryId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFlightArrivalCountryId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Flight.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtFlightArrivalCountryName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFlightArrivalCountryName_Internalname, "ArrivalCountry Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFlightArrivalCountryName_Internalname, StringUtil.RTrim( A30FlightArrivalCountryName), StringUtil.RTrim( context.localUtil.Format( A30FlightArrivalCountryName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFlightArrivalCountryName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFlightArrivalCountryName_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Flight.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtFlightArrivalCityId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFlightArrivalCityId_Internalname, "ArrivalCity Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFlightArrivalCityId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A31FlightArrivalCityId), 4, 0, ".", "")), StringUtil.LTrim( ((edtFlightArrivalCityId_Enabled!=0) ? context.localUtil.Format( (decimal)(A31FlightArrivalCityId), "ZZZ9") : context.localUtil.Format( (decimal)(A31FlightArrivalCityId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,89);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFlightArrivalCityId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFlightArrivalCityId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Flight.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtFlightArrivalCityName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFlightArrivalCityName_Internalname, "ArrivalCity Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFlightArrivalCityName_Internalname, StringUtil.RTrim( A32FlightArrivalCityName), StringUtil.RTrim( context.localUtil.Format( A32FlightArrivalCityName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,94);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFlightArrivalCityName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFlightArrivalCityName_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Flight.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtFlightPrice_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFlightPrice_Internalname, "Price", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFlightPrice_Internalname, StringUtil.LTrim( StringUtil.NToC( A33FlightPrice, 9, 2, ".", "")), StringUtil.LTrim( ((edtFlightPrice_Enabled!=0) ? context.localUtil.Format( A33FlightPrice, "ZZZZZ9.99") : context.localUtil.Format( A33FlightPrice, "ZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,99);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFlightPrice_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFlightPrice_Enabled, 0, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Price", "end", false, "", "HLP_Flight.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtFlightDiscountPercentage_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFlightDiscountPercentage_Internalname, "Discount Percentage", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFlightDiscountPercentage_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A34FlightDiscountPercentage), 3, 0, ".", "")), StringUtil.LTrim( ((edtFlightDiscountPercentage_Enabled!=0) ? context.localUtil.Format( (decimal)(A34FlightDiscountPercentage), "ZZ9") : context.localUtil.Format( (decimal)(A34FlightDiscountPercentage), "ZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,104);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFlightDiscountPercentage_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFlightDiscountPercentage_Enabled, 0, "text", "1", 3, "chr", 1, "row", 3, 0, 0, 0, 0, -1, 0, true, "Percentage", "end", false, "", "HLP_Flight.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAirlineId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAirlineId_Internalname, "Airline Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAirlineId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A36AirlineId), 4, 0, ".", "")), StringUtil.LTrim( ((edtAirlineId_Enabled!=0) ? context.localUtil.Format( (decimal)(A36AirlineId), "ZZZ9") : context.localUtil.Format( (decimal)(A36AirlineId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,109);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAirlineId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAirlineId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Flight.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_36_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_36_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_36_Internalname, sImgUrl, imgprompt_36_Link, "", "", context.GetTheme( ), imgprompt_36_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Flight.htm");
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
         GxWebStd.gx_label_element( context, edtAirlineName_Internalname, "Airline Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 114,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAirlineName_Internalname, StringUtil.RTrim( A37AirlineName), StringUtil.RTrim( context.localUtil.Format( A37AirlineName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,114);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAirlineName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAirlineName_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Flight.htm");
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
         GxWebStd.gx_label_element( context, edtAirlineDiscountPercentage_Internalname, "Airline Discount Percentage", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 119,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAirlineDiscountPercentage_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A38AirlineDiscountPercentage), 3, 0, ".", "")), StringUtil.LTrim( ((edtAirlineDiscountPercentage_Enabled!=0) ? context.localUtil.Format( (decimal)(A38AirlineDiscountPercentage), "ZZ9") : context.localUtil.Format( (decimal)(A38AirlineDiscountPercentage), "ZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,119);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAirlineDiscountPercentage_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAirlineDiscountPercentage_Enabled, 0, "text", "1", 3, "chr", 1, "row", 3, 0, 0, 0, 0, -1, 0, true, "Percentage", "end", false, "", "HLP_Flight.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtFlightFinalPrice_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFlightFinalPrice_Internalname, "Final Price", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 124,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFlightFinalPrice_Internalname, StringUtil.LTrim( StringUtil.NToC( A35FlightFinalPrice, 9, 2, ".", "")), StringUtil.LTrim( ((edtFlightFinalPrice_Enabled!=0) ? context.localUtil.Format( A35FlightFinalPrice, "ZZZZZ9.99") : context.localUtil.Format( A35FlightFinalPrice, "ZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,124);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFlightFinalPrice_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFlightFinalPrice_Enabled, 0, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Price", "end", false, "", "HLP_Flight.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtFlightCapacity_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFlightCapacity_Internalname, "Capacity", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 129,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFlightCapacity_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A40FlightCapacity), 4, 0, ".", "")), StringUtil.LTrim( ((edtFlightCapacity_Enabled!=0) ? context.localUtil.Format( (decimal)(A40FlightCapacity), "ZZZ9") : context.localUtil.Format( (decimal)(A40FlightCapacity), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,129);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFlightCapacity_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFlightCapacity_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Flight.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSeattable_Internalname, 1, 0, "px", 0, "px", "form__table-level", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitleseat_Internalname, "Seat", "", "", lblTitleseat_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-04", 0, "", 1, 1, 0, 0, "HLP_Flight.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         gxdraw_Gridflight_seat( ) ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 146,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirm", bttBtn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Flight.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 148,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Flight.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 150,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Flight.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "end", "Middle", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void gxdraw_Gridflight_seat( )
      {
         /*  Grid Control  */
         StartGridControl138( ) ;
         nGXsfl_138_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount9 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_9 = 1;
               ScanStart069( ) ;
               while ( RcdFound9 != 0 )
               {
                  init_level_properties9( ) ;
                  getByPrimaryKey069( ) ;
                  AddRow069( ) ;
                  ScanNext069( ) ;
               }
               ScanEnd069( ) ;
               nBlankRcdCount9 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            B40FlightCapacity = A40FlightCapacity;
            n40FlightCapacity = false;
            AssignAttri("", false, "A40FlightCapacity", StringUtil.LTrimStr( (decimal)(A40FlightCapacity), 4, 0));
            standaloneNotModal069( ) ;
            standaloneModal069( ) ;
            sMode9 = Gx_mode;
            while ( nGXsfl_138_idx < nRC_GXsfl_138 )
            {
               bGXsfl_138_Refreshing = true;
               ReadRow069( ) ;
               edtFlightSeatId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "FLIGHTSEATID_"+sGXsfl_138_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtFlightSeatId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFlightSeatId_Enabled), 5, 0), !bGXsfl_138_Refreshing);
               cmbFlightSeatChar.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "FLIGHTSEATCHAR_"+sGXsfl_138_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, cmbFlightSeatChar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbFlightSeatChar.Enabled), 5, 0), !bGXsfl_138_Refreshing);
               cmbFlightSeatLocation.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "FLIGHTSEATLOCATION_"+sGXsfl_138_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, cmbFlightSeatLocation_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbFlightSeatLocation.Enabled), 5, 0), !bGXsfl_138_Refreshing);
               if ( ( nRcdExists_9 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal069( ) ;
               }
               SendRow069( ) ;
               bGXsfl_138_Refreshing = false;
            }
            Gx_mode = sMode9;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A40FlightCapacity = B40FlightCapacity;
            n40FlightCapacity = false;
            AssignAttri("", false, "A40FlightCapacity", StringUtil.LTrimStr( (decimal)(A40FlightCapacity), 4, 0));
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount9 = 5;
            nRcdExists_9 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart069( ) ;
               while ( RcdFound9 != 0 )
               {
                  sGXsfl_138_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_138_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_1389( ) ;
                  init_level_properties9( ) ;
                  standaloneNotModal069( ) ;
                  getByPrimaryKey069( ) ;
                  standaloneModal069( ) ;
                  AddRow069( ) ;
                  ScanNext069( ) ;
               }
               ScanEnd069( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         sMode9 = Gx_mode;
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sGXsfl_138_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_138_idx+1), 4, 0), 4, "0");
         SubsflControlProps_1389( ) ;
         InitAll069( ) ;
         init_level_properties9( ) ;
         B40FlightCapacity = A40FlightCapacity;
         n40FlightCapacity = false;
         AssignAttri("", false, "A40FlightCapacity", StringUtil.LTrimStr( (decimal)(A40FlightCapacity), 4, 0));
         nRcdExists_9 = 0;
         nIsMod_9 = 0;
         nRcdDeleted_9 = 0;
         nBlankRcdCount9 = (short)(nBlankRcdUsr9+nBlankRcdCount9);
         fRowAdded = 0;
         while ( nBlankRcdCount9 > 0 )
         {
            standaloneNotModal069( ) ;
            standaloneModal069( ) ;
            AddRow069( ) ;
            if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
            {
               fRowAdded = 1;
               GX_FocusControl = edtFlightSeatId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nBlankRcdCount9 = (short)(nBlankRcdCount9-1);
         }
         Gx_mode = sMode9;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         A40FlightCapacity = B40FlightCapacity;
         n40FlightCapacity = false;
         AssignAttri("", false, "A40FlightCapacity", StringUtil.LTrimStr( (decimal)(A40FlightCapacity), 4, 0));
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridflight_seatContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridflight_seat", Gridflight_seatContainer, subGridflight_seat_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridflight_seatContainerData", Gridflight_seatContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridflight_seatContainerData"+"V", Gridflight_seatContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridflight_seatContainerData"+"V"+"\" value='"+Gridflight_seatContainer.GridValuesHidden()+"'/>") ;
         }
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
            Z20FlightId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z20FlightId"), ".", ","), 18, MidpointRounding.ToEven));
            Z33FlightPrice = context.localUtil.CToN( cgiGet( "Z33FlightPrice"), ".", ",");
            Z34FlightDiscountPercentage = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z34FlightDiscountPercentage"), ".", ","), 18, MidpointRounding.ToEven));
            Z36AirlineId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z36AirlineId"), ".", ","), 18, MidpointRounding.ToEven));
            n36AirlineId = ((0==A36AirlineId) ? true : false);
            Z21FlightDepartureAirportId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z21FlightDepartureAirportId"), ".", ","), 18, MidpointRounding.ToEven));
            Z23FlightArrivalAirportId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z23FlightArrivalAirportId"), ".", ","), 18, MidpointRounding.ToEven));
            O40FlightCapacity = (short)(Math.Round(context.localUtil.CToN( cgiGet( "O40FlightCapacity"), ".", ","), 18, MidpointRounding.ToEven));
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            nRC_GXsfl_138 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_138"), ".", ","), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtFlightId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtFlightId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "FLIGHTID");
               AnyError = 1;
               GX_FocusControl = edtFlightId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A20FlightId = 0;
               AssignAttri("", false, "A20FlightId", StringUtil.LTrimStr( (decimal)(A20FlightId), 4, 0));
            }
            else
            {
               A20FlightId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtFlightId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A20FlightId", StringUtil.LTrimStr( (decimal)(A20FlightId), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtFlightDepartureAirportId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtFlightDepartureAirportId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "FLIGHTDEPARTUREAIRPORTID");
               AnyError = 1;
               GX_FocusControl = edtFlightDepartureAirportId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A21FlightDepartureAirportId = 0;
               AssignAttri("", false, "A21FlightDepartureAirportId", StringUtil.LTrimStr( (decimal)(A21FlightDepartureAirportId), 4, 0));
            }
            else
            {
               A21FlightDepartureAirportId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtFlightDepartureAirportId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A21FlightDepartureAirportId", StringUtil.LTrimStr( (decimal)(A21FlightDepartureAirportId), 4, 0));
            }
            A22FlightDepartureAirportName = cgiGet( edtFlightDepartureAirportName_Internalname);
            AssignAttri("", false, "A22FlightDepartureAirportName", A22FlightDepartureAirportName);
            A25FlightDepartureCountryId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtFlightDepartureCountryId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A25FlightDepartureCountryId", StringUtil.LTrimStr( (decimal)(A25FlightDepartureCountryId), 4, 0));
            A26FlightDepartureCountryName = cgiGet( edtFlightDepartureCountryName_Internalname);
            AssignAttri("", false, "A26FlightDepartureCountryName", A26FlightDepartureCountryName);
            A27FlightDepartureCityId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtFlightDepartureCityId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A27FlightDepartureCityId", StringUtil.LTrimStr( (decimal)(A27FlightDepartureCityId), 4, 0));
            A28FlightDepartureCityName = cgiGet( edtFlightDepartureCityName_Internalname);
            AssignAttri("", false, "A28FlightDepartureCityName", A28FlightDepartureCityName);
            if ( ( ( context.localUtil.CToN( cgiGet( edtFlightArrivalAirportId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtFlightArrivalAirportId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "FLIGHTARRIVALAIRPORTID");
               AnyError = 1;
               GX_FocusControl = edtFlightArrivalAirportId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A23FlightArrivalAirportId = 0;
               AssignAttri("", false, "A23FlightArrivalAirportId", StringUtil.LTrimStr( (decimal)(A23FlightArrivalAirportId), 4, 0));
            }
            else
            {
               A23FlightArrivalAirportId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtFlightArrivalAirportId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A23FlightArrivalAirportId", StringUtil.LTrimStr( (decimal)(A23FlightArrivalAirportId), 4, 0));
            }
            A24FlightArrivalAirportName = cgiGet( edtFlightArrivalAirportName_Internalname);
            AssignAttri("", false, "A24FlightArrivalAirportName", A24FlightArrivalAirportName);
            A29FlightArrivalCountryId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtFlightArrivalCountryId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A29FlightArrivalCountryId", StringUtil.LTrimStr( (decimal)(A29FlightArrivalCountryId), 4, 0));
            A30FlightArrivalCountryName = cgiGet( edtFlightArrivalCountryName_Internalname);
            AssignAttri("", false, "A30FlightArrivalCountryName", A30FlightArrivalCountryName);
            A31FlightArrivalCityId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtFlightArrivalCityId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A31FlightArrivalCityId", StringUtil.LTrimStr( (decimal)(A31FlightArrivalCityId), 4, 0));
            A32FlightArrivalCityName = cgiGet( edtFlightArrivalCityName_Internalname);
            AssignAttri("", false, "A32FlightArrivalCityName", A32FlightArrivalCityName);
            if ( ( ( context.localUtil.CToN( cgiGet( edtFlightPrice_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtFlightPrice_Internalname), ".", ",") > 999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "FLIGHTPRICE");
               AnyError = 1;
               GX_FocusControl = edtFlightPrice_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A33FlightPrice = 0;
               AssignAttri("", false, "A33FlightPrice", StringUtil.LTrimStr( A33FlightPrice, 9, 2));
            }
            else
            {
               A33FlightPrice = context.localUtil.CToN( cgiGet( edtFlightPrice_Internalname), ".", ",");
               AssignAttri("", false, "A33FlightPrice", StringUtil.LTrimStr( A33FlightPrice, 9, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtFlightDiscountPercentage_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtFlightDiscountPercentage_Internalname), ".", ",") > Convert.ToDecimal( 999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "FLIGHTDISCOUNTPERCENTAGE");
               AnyError = 1;
               GX_FocusControl = edtFlightDiscountPercentage_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A34FlightDiscountPercentage = 0;
               AssignAttri("", false, "A34FlightDiscountPercentage", StringUtil.LTrimStr( (decimal)(A34FlightDiscountPercentage), 3, 0));
            }
            else
            {
               A34FlightDiscountPercentage = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtFlightDiscountPercentage_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A34FlightDiscountPercentage", StringUtil.LTrimStr( (decimal)(A34FlightDiscountPercentage), 3, 0));
            }
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
            n36AirlineId = ((0==A36AirlineId) ? true : false);
            A37AirlineName = cgiGet( edtAirlineName_Internalname);
            AssignAttri("", false, "A37AirlineName", A37AirlineName);
            A38AirlineDiscountPercentage = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtAirlineDiscountPercentage_Internalname), ".", ","), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A38AirlineDiscountPercentage", StringUtil.LTrimStr( (decimal)(A38AirlineDiscountPercentage), 3, 0));
            A35FlightFinalPrice = context.localUtil.CToN( cgiGet( edtFlightFinalPrice_Internalname), ".", ",");
            AssignAttri("", false, "A35FlightFinalPrice", StringUtil.LTrimStr( A35FlightFinalPrice, 9, 2));
            A40FlightCapacity = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtFlightCapacity_Internalname), ".", ","), 18, MidpointRounding.ToEven));
            n40FlightCapacity = false;
            AssignAttri("", false, "A40FlightCapacity", StringUtil.LTrimStr( (decimal)(A40FlightCapacity), 4, 0));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            standaloneNotModal( ) ;
         }
         else
         {
            standaloneNotModal( ) ;
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
            {
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               A20FlightId = (short)(Math.Round(NumberUtil.Val( GetPar( "FlightId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A20FlightId", StringUtil.LTrimStr( (decimal)(A20FlightId), 4, 0));
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
                        sEvtType = StringUtil.Right( sEvt, 4);
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
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
               InitAll067( ) ;
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
         DisableAttributes067( ) ;
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

      protected void CONFIRM_069( )
      {
         s40FlightCapacity = O40FlightCapacity;
         n40FlightCapacity = false;
         AssignAttri("", false, "A40FlightCapacity", StringUtil.LTrimStr( (decimal)(A40FlightCapacity), 4, 0));
         nGXsfl_138_idx = 0;
         while ( nGXsfl_138_idx < nRC_GXsfl_138 )
         {
            ReadRow069( ) ;
            if ( ( nRcdExists_9 != 0 ) || ( nIsMod_9 != 0 ) )
            {
               GetKey069( ) ;
               if ( ( nRcdExists_9 == 0 ) && ( nRcdDeleted_9 == 0 ) )
               {
                  if ( RcdFound9 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate069( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable069( ) ;
                        CloseExtendedTableCursors069( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                        O40FlightCapacity = A40FlightCapacity;
                        n40FlightCapacity = false;
                        AssignAttri("", false, "A40FlightCapacity", StringUtil.LTrimStr( (decimal)(A40FlightCapacity), 4, 0));
                     }
                  }
                  else
                  {
                     GXCCtl = "FLIGHTSEATID_" + sGXsfl_138_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtFlightSeatId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound9 != 0 )
                  {
                     if ( nRcdDeleted_9 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey069( ) ;
                        Load069( ) ;
                        BeforeValidate069( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls069( ) ;
                           O40FlightCapacity = A40FlightCapacity;
                           n40FlightCapacity = false;
                           AssignAttri("", false, "A40FlightCapacity", StringUtil.LTrimStr( (decimal)(A40FlightCapacity), 4, 0));
                        }
                     }
                     else
                     {
                        if ( nIsMod_9 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate069( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable069( ) ;
                              CloseExtendedTableCursors069( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                              O40FlightCapacity = A40FlightCapacity;
                              n40FlightCapacity = false;
                              AssignAttri("", false, "A40FlightCapacity", StringUtil.LTrimStr( (decimal)(A40FlightCapacity), 4, 0));
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_9 == 0 )
                     {
                        GXCCtl = "FLIGHTSEATID_" + sGXsfl_138_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtFlightSeatId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtFlightSeatId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A41FlightSeatId), 4, 0, ".", ""))) ;
            ChangePostValue( cmbFlightSeatChar_Internalname, StringUtil.RTrim( A42FlightSeatChar)) ;
            ChangePostValue( cmbFlightSeatLocation_Internalname, StringUtil.RTrim( A43FlightSeatLocation)) ;
            ChangePostValue( "ZT_"+"Z41FlightSeatId_"+sGXsfl_138_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z41FlightSeatId), 4, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z42FlightSeatChar_"+sGXsfl_138_idx, StringUtil.RTrim( Z42FlightSeatChar)) ;
            ChangePostValue( "ZT_"+"Z43FlightSeatLocation_"+sGXsfl_138_idx, StringUtil.RTrim( Z43FlightSeatLocation)) ;
            ChangePostValue( "nRcdDeleted_9_"+sGXsfl_138_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_9), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_9_"+sGXsfl_138_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_9), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_9_"+sGXsfl_138_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_9), 4, 0, ".", ""))) ;
            if ( nIsMod_9 != 0 )
            {
               ChangePostValue( "FLIGHTSEATID_"+sGXsfl_138_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtFlightSeatId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "FLIGHTSEATCHAR_"+sGXsfl_138_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbFlightSeatChar.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "FLIGHTSEATLOCATION_"+sGXsfl_138_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbFlightSeatLocation.Enabled), 5, 0, ".", ""))) ;
            }
         }
         O40FlightCapacity = s40FlightCapacity;
         n40FlightCapacity = false;
         AssignAttri("", false, "A40FlightCapacity", StringUtil.LTrimStr( (decimal)(A40FlightCapacity), 4, 0));
         /* Start of After( level) rules */
         if ( A40FlightCapacity < 8 )
         {
            GX_msglist.addItem("The seat quantity mustn`t be less than eight", 1, "");
            AnyError = 1;
         }
         /* End of After( level) rules */
      }

      protected void ResetCaption060( )
      {
      }

      protected void ZM067( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z33FlightPrice = T00065_A33FlightPrice[0];
               Z34FlightDiscountPercentage = T00065_A34FlightDiscountPercentage[0];
               Z36AirlineId = T00065_A36AirlineId[0];
               Z21FlightDepartureAirportId = T00065_A21FlightDepartureAirportId[0];
               Z23FlightArrivalAirportId = T00065_A23FlightArrivalAirportId[0];
            }
            else
            {
               Z33FlightPrice = A33FlightPrice;
               Z34FlightDiscountPercentage = A34FlightDiscountPercentage;
               Z36AirlineId = A36AirlineId;
               Z21FlightDepartureAirportId = A21FlightDepartureAirportId;
               Z23FlightArrivalAirportId = A23FlightArrivalAirportId;
            }
         }
         if ( GX_JID == -6 )
         {
            Z20FlightId = A20FlightId;
            Z33FlightPrice = A33FlightPrice;
            Z34FlightDiscountPercentage = A34FlightDiscountPercentage;
            Z36AirlineId = A36AirlineId;
            Z21FlightDepartureAirportId = A21FlightDepartureAirportId;
            Z23FlightArrivalAirportId = A23FlightArrivalAirportId;
            Z40FlightCapacity = A40FlightCapacity;
            Z22FlightDepartureAirportName = A22FlightDepartureAirportName;
            Z25FlightDepartureCountryId = A25FlightDepartureCountryId;
            Z27FlightDepartureCityId = A27FlightDepartureCityId;
            Z26FlightDepartureCountryName = A26FlightDepartureCountryName;
            Z28FlightDepartureCityName = A28FlightDepartureCityName;
            Z24FlightArrivalAirportName = A24FlightArrivalAirportName;
            Z29FlightArrivalCountryId = A29FlightArrivalCountryId;
            Z31FlightArrivalCityId = A31FlightArrivalCityId;
            Z30FlightArrivalCountryName = A30FlightArrivalCountryName;
            Z32FlightArrivalCityName = A32FlightArrivalCityName;
            Z37AirlineName = A37AirlineName;
            Z38AirlineDiscountPercentage = A38AirlineDiscountPercentage;
         }
      }

      protected void standaloneNotModal( )
      {
         imgprompt_21_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0060.aspx"+"',["+"{Ctrl:gx.dom.el('"+"FLIGHTDEPARTUREAIRPORTID"+"'), id:'"+"FLIGHTDEPARTUREAIRPORTID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_23_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0060.aspx"+"',["+"{Ctrl:gx.dom.el('"+"FLIGHTARRIVALAIRPORTID"+"'), id:'"+"FLIGHTARRIVALAIRPORTID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_36_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0080.aspx"+"',["+"{Ctrl:gx.dom.el('"+"AIRLINEID"+"'), id:'"+"AIRLINEID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
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

      protected void Load067( )
      {
         /* Using cursor T000616 */
         pr_default.execute(12, new Object[] {A20FlightId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound7 = 1;
            A22FlightDepartureAirportName = T000616_A22FlightDepartureAirportName[0];
            AssignAttri("", false, "A22FlightDepartureAirportName", A22FlightDepartureAirportName);
            A26FlightDepartureCountryName = T000616_A26FlightDepartureCountryName[0];
            AssignAttri("", false, "A26FlightDepartureCountryName", A26FlightDepartureCountryName);
            A28FlightDepartureCityName = T000616_A28FlightDepartureCityName[0];
            AssignAttri("", false, "A28FlightDepartureCityName", A28FlightDepartureCityName);
            A24FlightArrivalAirportName = T000616_A24FlightArrivalAirportName[0];
            AssignAttri("", false, "A24FlightArrivalAirportName", A24FlightArrivalAirportName);
            A30FlightArrivalCountryName = T000616_A30FlightArrivalCountryName[0];
            AssignAttri("", false, "A30FlightArrivalCountryName", A30FlightArrivalCountryName);
            A32FlightArrivalCityName = T000616_A32FlightArrivalCityName[0];
            AssignAttri("", false, "A32FlightArrivalCityName", A32FlightArrivalCityName);
            A33FlightPrice = T000616_A33FlightPrice[0];
            AssignAttri("", false, "A33FlightPrice", StringUtil.LTrimStr( A33FlightPrice, 9, 2));
            A34FlightDiscountPercentage = T000616_A34FlightDiscountPercentage[0];
            AssignAttri("", false, "A34FlightDiscountPercentage", StringUtil.LTrimStr( (decimal)(A34FlightDiscountPercentage), 3, 0));
            A37AirlineName = T000616_A37AirlineName[0];
            AssignAttri("", false, "A37AirlineName", A37AirlineName);
            A38AirlineDiscountPercentage = T000616_A38AirlineDiscountPercentage[0];
            AssignAttri("", false, "A38AirlineDiscountPercentage", StringUtil.LTrimStr( (decimal)(A38AirlineDiscountPercentage), 3, 0));
            A36AirlineId = T000616_A36AirlineId[0];
            n36AirlineId = T000616_n36AirlineId[0];
            AssignAttri("", false, "A36AirlineId", StringUtil.LTrimStr( (decimal)(A36AirlineId), 4, 0));
            A21FlightDepartureAirportId = T000616_A21FlightDepartureAirportId[0];
            AssignAttri("", false, "A21FlightDepartureAirportId", StringUtil.LTrimStr( (decimal)(A21FlightDepartureAirportId), 4, 0));
            A23FlightArrivalAirportId = T000616_A23FlightArrivalAirportId[0];
            AssignAttri("", false, "A23FlightArrivalAirportId", StringUtil.LTrimStr( (decimal)(A23FlightArrivalAirportId), 4, 0));
            A25FlightDepartureCountryId = T000616_A25FlightDepartureCountryId[0];
            AssignAttri("", false, "A25FlightDepartureCountryId", StringUtil.LTrimStr( (decimal)(A25FlightDepartureCountryId), 4, 0));
            A27FlightDepartureCityId = T000616_A27FlightDepartureCityId[0];
            AssignAttri("", false, "A27FlightDepartureCityId", StringUtil.LTrimStr( (decimal)(A27FlightDepartureCityId), 4, 0));
            A29FlightArrivalCountryId = T000616_A29FlightArrivalCountryId[0];
            AssignAttri("", false, "A29FlightArrivalCountryId", StringUtil.LTrimStr( (decimal)(A29FlightArrivalCountryId), 4, 0));
            A31FlightArrivalCityId = T000616_A31FlightArrivalCityId[0];
            AssignAttri("", false, "A31FlightArrivalCityId", StringUtil.LTrimStr( (decimal)(A31FlightArrivalCityId), 4, 0));
            A40FlightCapacity = T000616_A40FlightCapacity[0];
            n40FlightCapacity = T000616_n40FlightCapacity[0];
            AssignAttri("", false, "A40FlightCapacity", StringUtil.LTrimStr( (decimal)(A40FlightCapacity), 4, 0));
            ZM067( -6) ;
         }
         pr_default.close(12);
         OnLoadActions067( ) ;
      }

      protected void OnLoadActions067( )
      {
         O40FlightCapacity = A40FlightCapacity;
         n40FlightCapacity = false;
         AssignAttri("", false, "A40FlightCapacity", StringUtil.LTrimStr( (decimal)(A40FlightCapacity), 4, 0));
         if ( A38AirlineDiscountPercentage > A34FlightDiscountPercentage )
         {
            A35FlightFinalPrice = (decimal)(A33FlightPrice*(1-A38AirlineDiscountPercentage/ (decimal)(100)));
            AssignAttri("", false, "A35FlightFinalPrice", StringUtil.LTrimStr( A35FlightFinalPrice, 9, 2));
         }
         else
         {
            A35FlightFinalPrice = (decimal)(A33FlightPrice*(1-A34FlightDiscountPercentage/ (decimal)(100)));
            AssignAttri("", false, "A35FlightFinalPrice", StringUtil.LTrimStr( A35FlightFinalPrice, 9, 2));
         }
      }

      protected void CheckExtendedTable067( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T000614 */
         pr_default.execute(11, new Object[] {A20FlightId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            A40FlightCapacity = T000614_A40FlightCapacity[0];
            n40FlightCapacity = T000614_n40FlightCapacity[0];
            AssignAttri("", false, "A40FlightCapacity", StringUtil.LTrimStr( (decimal)(A40FlightCapacity), 4, 0));
         }
         else
         {
            A40FlightCapacity = 0;
            n40FlightCapacity = false;
            AssignAttri("", false, "A40FlightCapacity", StringUtil.LTrimStr( (decimal)(A40FlightCapacity), 4, 0));
         }
         pr_default.close(11);
         /* Using cursor T00067 */
         pr_default.execute(5, new Object[] {A21FlightDepartureAirportId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No matching 'Flight Departure Airport'.", "ForeignKeyNotFound", 1, "FLIGHTDEPARTUREAIRPORTID");
            AnyError = 1;
            GX_FocusControl = edtFlightDepartureAirportId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A22FlightDepartureAirportName = T00067_A22FlightDepartureAirportName[0];
         AssignAttri("", false, "A22FlightDepartureAirportName", A22FlightDepartureAirportName);
         A25FlightDepartureCountryId = T00067_A25FlightDepartureCountryId[0];
         AssignAttri("", false, "A25FlightDepartureCountryId", StringUtil.LTrimStr( (decimal)(A25FlightDepartureCountryId), 4, 0));
         A27FlightDepartureCityId = T00067_A27FlightDepartureCityId[0];
         AssignAttri("", false, "A27FlightDepartureCityId", StringUtil.LTrimStr( (decimal)(A27FlightDepartureCityId), 4, 0));
         pr_default.close(5);
         /* Using cursor T00069 */
         pr_default.execute(7, new Object[] {A25FlightDepartureCountryId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No matching 'Flight Departure Airport'.", "ForeignKeyNotFound", 1, "FLIGHTDEPARTURECOUNTRYID");
            AnyError = 1;
         }
         A26FlightDepartureCountryName = T00069_A26FlightDepartureCountryName[0];
         AssignAttri("", false, "A26FlightDepartureCountryName", A26FlightDepartureCountryName);
         pr_default.close(7);
         /* Using cursor T000610 */
         pr_default.execute(8, new Object[] {A25FlightDepartureCountryId, A27FlightDepartureCityId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No matching 'Flight Departure Airport'.", "ForeignKeyNotFound", 1, "FLIGHTDEPARTURECITYID");
            AnyError = 1;
         }
         A28FlightDepartureCityName = T000610_A28FlightDepartureCityName[0];
         AssignAttri("", false, "A28FlightDepartureCityName", A28FlightDepartureCityName);
         pr_default.close(8);
         /* Using cursor T00068 */
         pr_default.execute(6, new Object[] {A23FlightArrivalAirportId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No matching 'Flight Arrival Airport'.", "ForeignKeyNotFound", 1, "FLIGHTARRIVALAIRPORTID");
            AnyError = 1;
            GX_FocusControl = edtFlightArrivalAirportId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A24FlightArrivalAirportName = T00068_A24FlightArrivalAirportName[0];
         AssignAttri("", false, "A24FlightArrivalAirportName", A24FlightArrivalAirportName);
         A29FlightArrivalCountryId = T00068_A29FlightArrivalCountryId[0];
         AssignAttri("", false, "A29FlightArrivalCountryId", StringUtil.LTrimStr( (decimal)(A29FlightArrivalCountryId), 4, 0));
         A31FlightArrivalCityId = T00068_A31FlightArrivalCityId[0];
         AssignAttri("", false, "A31FlightArrivalCityId", StringUtil.LTrimStr( (decimal)(A31FlightArrivalCityId), 4, 0));
         pr_default.close(6);
         /* Using cursor T000611 */
         pr_default.execute(9, new Object[] {A29FlightArrivalCountryId});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem("No matching 'Flight Arrival Airport'.", "ForeignKeyNotFound", 1, "FLIGHTARRIVALCOUNTRYID");
            AnyError = 1;
         }
         A30FlightArrivalCountryName = T000611_A30FlightArrivalCountryName[0];
         AssignAttri("", false, "A30FlightArrivalCountryName", A30FlightArrivalCountryName);
         pr_default.close(9);
         /* Using cursor T000612 */
         pr_default.execute(10, new Object[] {A29FlightArrivalCountryId, A31FlightArrivalCityId});
         if ( (pr_default.getStatus(10) == 101) )
         {
            GX_msglist.addItem("No matching 'Flight Arrival Airport'.", "ForeignKeyNotFound", 1, "FLIGHTARRIVALCITYID");
            AnyError = 1;
         }
         A32FlightArrivalCityName = T000612_A32FlightArrivalCityName[0];
         AssignAttri("", false, "A32FlightArrivalCityName", A32FlightArrivalCityName);
         pr_default.close(10);
         /* Using cursor T00066 */
         pr_default.execute(4, new Object[] {n36AirlineId, A36AirlineId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A36AirlineId) ) )
            {
               GX_msglist.addItem("No matching 'Airline'.", "ForeignKeyNotFound", 1, "AIRLINEID");
               AnyError = 1;
               GX_FocusControl = edtAirlineId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A37AirlineName = T00066_A37AirlineName[0];
         AssignAttri("", false, "A37AirlineName", A37AirlineName);
         A38AirlineDiscountPercentage = T00066_A38AirlineDiscountPercentage[0];
         AssignAttri("", false, "A38AirlineDiscountPercentage", StringUtil.LTrimStr( (decimal)(A38AirlineDiscountPercentage), 3, 0));
         pr_default.close(4);
         if ( A38AirlineDiscountPercentage > A34FlightDiscountPercentage )
         {
            A35FlightFinalPrice = (decimal)(A33FlightPrice*(1-A38AirlineDiscountPercentage/ (decimal)(100)));
            AssignAttri("", false, "A35FlightFinalPrice", StringUtil.LTrimStr( A35FlightFinalPrice, 9, 2));
         }
         else
         {
            A35FlightFinalPrice = (decimal)(A33FlightPrice*(1-A34FlightDiscountPercentage/ (decimal)(100)));
            AssignAttri("", false, "A35FlightFinalPrice", StringUtil.LTrimStr( A35FlightFinalPrice, 9, 2));
         }
      }

      protected void CloseExtendedTableCursors067( )
      {
         pr_default.close(11);
         pr_default.close(5);
         pr_default.close(7);
         pr_default.close(8);
         pr_default.close(6);
         pr_default.close(9);
         pr_default.close(10);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_14( short A20FlightId )
      {
         /* Using cursor T000618 */
         pr_default.execute(13, new Object[] {A20FlightId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            A40FlightCapacity = T000618_A40FlightCapacity[0];
            n40FlightCapacity = T000618_n40FlightCapacity[0];
            AssignAttri("", false, "A40FlightCapacity", StringUtil.LTrimStr( (decimal)(A40FlightCapacity), 4, 0));
         }
         else
         {
            A40FlightCapacity = 0;
            n40FlightCapacity = false;
            AssignAttri("", false, "A40FlightCapacity", StringUtil.LTrimStr( (decimal)(A40FlightCapacity), 4, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A40FlightCapacity), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(13) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(13);
      }

      protected void gxLoad_8( short A21FlightDepartureAirportId )
      {
         /* Using cursor T000619 */
         pr_default.execute(14, new Object[] {A21FlightDepartureAirportId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No matching 'Flight Departure Airport'.", "ForeignKeyNotFound", 1, "FLIGHTDEPARTUREAIRPORTID");
            AnyError = 1;
            GX_FocusControl = edtFlightDepartureAirportId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A22FlightDepartureAirportName = T000619_A22FlightDepartureAirportName[0];
         AssignAttri("", false, "A22FlightDepartureAirportName", A22FlightDepartureAirportName);
         A25FlightDepartureCountryId = T000619_A25FlightDepartureCountryId[0];
         AssignAttri("", false, "A25FlightDepartureCountryId", StringUtil.LTrimStr( (decimal)(A25FlightDepartureCountryId), 4, 0));
         A27FlightDepartureCityId = T000619_A27FlightDepartureCityId[0];
         AssignAttri("", false, "A27FlightDepartureCityId", StringUtil.LTrimStr( (decimal)(A27FlightDepartureCityId), 4, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A22FlightDepartureAirportName))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A25FlightDepartureCountryId), 4, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A27FlightDepartureCityId), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(14) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(14);
      }

      protected void gxLoad_10( short A25FlightDepartureCountryId )
      {
         /* Using cursor T000620 */
         pr_default.execute(15, new Object[] {A25FlightDepartureCountryId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No matching 'Flight Departure Airport'.", "ForeignKeyNotFound", 1, "FLIGHTDEPARTURECOUNTRYID");
            AnyError = 1;
         }
         A26FlightDepartureCountryName = T000620_A26FlightDepartureCountryName[0];
         AssignAttri("", false, "A26FlightDepartureCountryName", A26FlightDepartureCountryName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A26FlightDepartureCountryName))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(15) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(15);
      }

      protected void gxLoad_11( short A25FlightDepartureCountryId ,
                                short A27FlightDepartureCityId )
      {
         /* Using cursor T000621 */
         pr_default.execute(16, new Object[] {A25FlightDepartureCountryId, A27FlightDepartureCityId});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No matching 'Flight Departure Airport'.", "ForeignKeyNotFound", 1, "FLIGHTDEPARTURECITYID");
            AnyError = 1;
         }
         A28FlightDepartureCityName = T000621_A28FlightDepartureCityName[0];
         AssignAttri("", false, "A28FlightDepartureCityName", A28FlightDepartureCityName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A28FlightDepartureCityName))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(16) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(16);
      }

      protected void gxLoad_9( short A23FlightArrivalAirportId )
      {
         /* Using cursor T000622 */
         pr_default.execute(17, new Object[] {A23FlightArrivalAirportId});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem("No matching 'Flight Arrival Airport'.", "ForeignKeyNotFound", 1, "FLIGHTARRIVALAIRPORTID");
            AnyError = 1;
            GX_FocusControl = edtFlightArrivalAirportId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A24FlightArrivalAirportName = T000622_A24FlightArrivalAirportName[0];
         AssignAttri("", false, "A24FlightArrivalAirportName", A24FlightArrivalAirportName);
         A29FlightArrivalCountryId = T000622_A29FlightArrivalCountryId[0];
         AssignAttri("", false, "A29FlightArrivalCountryId", StringUtil.LTrimStr( (decimal)(A29FlightArrivalCountryId), 4, 0));
         A31FlightArrivalCityId = T000622_A31FlightArrivalCityId[0];
         AssignAttri("", false, "A31FlightArrivalCityId", StringUtil.LTrimStr( (decimal)(A31FlightArrivalCityId), 4, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A24FlightArrivalAirportName))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A29FlightArrivalCountryId), 4, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A31FlightArrivalCityId), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(17) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(17);
      }

      protected void gxLoad_12( short A29FlightArrivalCountryId )
      {
         /* Using cursor T000623 */
         pr_default.execute(18, new Object[] {A29FlightArrivalCountryId});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem("No matching 'Flight Arrival Airport'.", "ForeignKeyNotFound", 1, "FLIGHTARRIVALCOUNTRYID");
            AnyError = 1;
         }
         A30FlightArrivalCountryName = T000623_A30FlightArrivalCountryName[0];
         AssignAttri("", false, "A30FlightArrivalCountryName", A30FlightArrivalCountryName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A30FlightArrivalCountryName))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(18) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(18);
      }

      protected void gxLoad_13( short A29FlightArrivalCountryId ,
                                short A31FlightArrivalCityId )
      {
         /* Using cursor T000624 */
         pr_default.execute(19, new Object[] {A29FlightArrivalCountryId, A31FlightArrivalCityId});
         if ( (pr_default.getStatus(19) == 101) )
         {
            GX_msglist.addItem("No matching 'Flight Arrival Airport'.", "ForeignKeyNotFound", 1, "FLIGHTARRIVALCITYID");
            AnyError = 1;
         }
         A32FlightArrivalCityName = T000624_A32FlightArrivalCityName[0];
         AssignAttri("", false, "A32FlightArrivalCityName", A32FlightArrivalCityName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A32FlightArrivalCityName))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(19) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(19);
      }

      protected void gxLoad_7( short A36AirlineId )
      {
         /* Using cursor T000625 */
         pr_default.execute(20, new Object[] {n36AirlineId, A36AirlineId});
         if ( (pr_default.getStatus(20) == 101) )
         {
            if ( ! ( (0==A36AirlineId) ) )
            {
               GX_msglist.addItem("No matching 'Airline'.", "ForeignKeyNotFound", 1, "AIRLINEID");
               AnyError = 1;
               GX_FocusControl = edtAirlineId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A37AirlineName = T000625_A37AirlineName[0];
         AssignAttri("", false, "A37AirlineName", A37AirlineName);
         A38AirlineDiscountPercentage = T000625_A38AirlineDiscountPercentage[0];
         AssignAttri("", false, "A38AirlineDiscountPercentage", StringUtil.LTrimStr( (decimal)(A38AirlineDiscountPercentage), 3, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A37AirlineName))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A38AirlineDiscountPercentage), 3, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(20) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(20);
      }

      protected void GetKey067( )
      {
         /* Using cursor T000626 */
         pr_default.execute(21, new Object[] {A20FlightId});
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound7 = 1;
         }
         else
         {
            RcdFound7 = 0;
         }
         pr_default.close(21);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00065 */
         pr_default.execute(3, new Object[] {A20FlightId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM067( 6) ;
            RcdFound7 = 1;
            A20FlightId = T00065_A20FlightId[0];
            AssignAttri("", false, "A20FlightId", StringUtil.LTrimStr( (decimal)(A20FlightId), 4, 0));
            A33FlightPrice = T00065_A33FlightPrice[0];
            AssignAttri("", false, "A33FlightPrice", StringUtil.LTrimStr( A33FlightPrice, 9, 2));
            A34FlightDiscountPercentage = T00065_A34FlightDiscountPercentage[0];
            AssignAttri("", false, "A34FlightDiscountPercentage", StringUtil.LTrimStr( (decimal)(A34FlightDiscountPercentage), 3, 0));
            A36AirlineId = T00065_A36AirlineId[0];
            n36AirlineId = T00065_n36AirlineId[0];
            AssignAttri("", false, "A36AirlineId", StringUtil.LTrimStr( (decimal)(A36AirlineId), 4, 0));
            A21FlightDepartureAirportId = T00065_A21FlightDepartureAirportId[0];
            AssignAttri("", false, "A21FlightDepartureAirportId", StringUtil.LTrimStr( (decimal)(A21FlightDepartureAirportId), 4, 0));
            A23FlightArrivalAirportId = T00065_A23FlightArrivalAirportId[0];
            AssignAttri("", false, "A23FlightArrivalAirportId", StringUtil.LTrimStr( (decimal)(A23FlightArrivalAirportId), 4, 0));
            Z20FlightId = A20FlightId;
            sMode7 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load067( ) ;
            if ( AnyError == 1 )
            {
               RcdFound7 = 0;
               InitializeNonKey067( ) ;
            }
            Gx_mode = sMode7;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound7 = 0;
            InitializeNonKey067( ) ;
            sMode7 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode7;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(3);
      }

      protected void getEqualNoModal( )
      {
         GetKey067( ) ;
         if ( RcdFound7 == 0 )
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
         RcdFound7 = 0;
         /* Using cursor T000627 */
         pr_default.execute(22, new Object[] {A20FlightId});
         if ( (pr_default.getStatus(22) != 101) )
         {
            while ( (pr_default.getStatus(22) != 101) && ( ( T000627_A20FlightId[0] < A20FlightId ) ) )
            {
               pr_default.readNext(22);
            }
            if ( (pr_default.getStatus(22) != 101) && ( ( T000627_A20FlightId[0] > A20FlightId ) ) )
            {
               A20FlightId = T000627_A20FlightId[0];
               AssignAttri("", false, "A20FlightId", StringUtil.LTrimStr( (decimal)(A20FlightId), 4, 0));
               RcdFound7 = 1;
            }
         }
         pr_default.close(22);
      }

      protected void move_previous( )
      {
         RcdFound7 = 0;
         /* Using cursor T000628 */
         pr_default.execute(23, new Object[] {A20FlightId});
         if ( (pr_default.getStatus(23) != 101) )
         {
            while ( (pr_default.getStatus(23) != 101) && ( ( T000628_A20FlightId[0] > A20FlightId ) ) )
            {
               pr_default.readNext(23);
            }
            if ( (pr_default.getStatus(23) != 101) && ( ( T000628_A20FlightId[0] < A20FlightId ) ) )
            {
               A20FlightId = T000628_A20FlightId[0];
               AssignAttri("", false, "A20FlightId", StringUtil.LTrimStr( (decimal)(A20FlightId), 4, 0));
               RcdFound7 = 1;
            }
         }
         pr_default.close(23);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey067( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            A40FlightCapacity = O40FlightCapacity;
            n40FlightCapacity = false;
            AssignAttri("", false, "A40FlightCapacity", StringUtil.LTrimStr( (decimal)(A40FlightCapacity), 4, 0));
            GX_FocusControl = edtFlightId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert067( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound7 == 1 )
            {
               if ( A20FlightId != Z20FlightId )
               {
                  A20FlightId = Z20FlightId;
                  AssignAttri("", false, "A20FlightId", StringUtil.LTrimStr( (decimal)(A20FlightId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "FLIGHTID");
                  AnyError = 1;
                  GX_FocusControl = edtFlightId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  A40FlightCapacity = O40FlightCapacity;
                  n40FlightCapacity = false;
                  AssignAttri("", false, "A40FlightCapacity", StringUtil.LTrimStr( (decimal)(A40FlightCapacity), 4, 0));
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtFlightId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  A40FlightCapacity = O40FlightCapacity;
                  n40FlightCapacity = false;
                  AssignAttri("", false, "A40FlightCapacity", StringUtil.LTrimStr( (decimal)(A40FlightCapacity), 4, 0));
                  Update067( ) ;
                  GX_FocusControl = edtFlightId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A20FlightId != Z20FlightId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  A40FlightCapacity = O40FlightCapacity;
                  n40FlightCapacity = false;
                  AssignAttri("", false, "A40FlightCapacity", StringUtil.LTrimStr( (decimal)(A40FlightCapacity), 4, 0));
                  GX_FocusControl = edtFlightId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert067( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "FLIGHTID");
                     AnyError = 1;
                     GX_FocusControl = edtFlightId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     A40FlightCapacity = O40FlightCapacity;
                     n40FlightCapacity = false;
                     AssignAttri("", false, "A40FlightCapacity", StringUtil.LTrimStr( (decimal)(A40FlightCapacity), 4, 0));
                     GX_FocusControl = edtFlightId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert067( ) ;
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
         if ( A20FlightId != Z20FlightId )
         {
            A20FlightId = Z20FlightId;
            AssignAttri("", false, "A20FlightId", StringUtil.LTrimStr( (decimal)(A20FlightId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "FLIGHTID");
            AnyError = 1;
            GX_FocusControl = edtFlightId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            A40FlightCapacity = O40FlightCapacity;
            n40FlightCapacity = false;
            AssignAttri("", false, "A40FlightCapacity", StringUtil.LTrimStr( (decimal)(A40FlightCapacity), 4, 0));
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtFlightId_Internalname;
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
         if ( RcdFound7 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "FLIGHTID");
            AnyError = 1;
            GX_FocusControl = edtFlightId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtFlightDepartureAirportId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart067( ) ;
         if ( RcdFound7 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtFlightDepartureAirportId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd067( ) ;
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
         if ( RcdFound7 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtFlightDepartureAirportId_Internalname;
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
         if ( RcdFound7 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtFlightDepartureAirportId_Internalname;
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
         ScanStart067( ) ;
         if ( RcdFound7 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound7 != 0 )
            {
               ScanNext067( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtFlightDepartureAirportId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd067( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency067( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00064 */
            pr_default.execute(2, new Object[] {A20FlightId});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Flight"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(2) == 101) || ( Z33FlightPrice != T00064_A33FlightPrice[0] ) || ( Z34FlightDiscountPercentage != T00064_A34FlightDiscountPercentage[0] ) || ( Z36AirlineId != T00064_A36AirlineId[0] ) || ( Z21FlightDepartureAirportId != T00064_A21FlightDepartureAirportId[0] ) || ( Z23FlightArrivalAirportId != T00064_A23FlightArrivalAirportId[0] ) )
            {
               if ( Z33FlightPrice != T00064_A33FlightPrice[0] )
               {
                  GXUtil.WriteLog("flight:[seudo value changed for attri]"+"FlightPrice");
                  GXUtil.WriteLogRaw("Old: ",Z33FlightPrice);
                  GXUtil.WriteLogRaw("Current: ",T00064_A33FlightPrice[0]);
               }
               if ( Z34FlightDiscountPercentage != T00064_A34FlightDiscountPercentage[0] )
               {
                  GXUtil.WriteLog("flight:[seudo value changed for attri]"+"FlightDiscountPercentage");
                  GXUtil.WriteLogRaw("Old: ",Z34FlightDiscountPercentage);
                  GXUtil.WriteLogRaw("Current: ",T00064_A34FlightDiscountPercentage[0]);
               }
               if ( Z36AirlineId != T00064_A36AirlineId[0] )
               {
                  GXUtil.WriteLog("flight:[seudo value changed for attri]"+"AirlineId");
                  GXUtil.WriteLogRaw("Old: ",Z36AirlineId);
                  GXUtil.WriteLogRaw("Current: ",T00064_A36AirlineId[0]);
               }
               if ( Z21FlightDepartureAirportId != T00064_A21FlightDepartureAirportId[0] )
               {
                  GXUtil.WriteLog("flight:[seudo value changed for attri]"+"FlightDepartureAirportId");
                  GXUtil.WriteLogRaw("Old: ",Z21FlightDepartureAirportId);
                  GXUtil.WriteLogRaw("Current: ",T00064_A21FlightDepartureAirportId[0]);
               }
               if ( Z23FlightArrivalAirportId != T00064_A23FlightArrivalAirportId[0] )
               {
                  GXUtil.WriteLog("flight:[seudo value changed for attri]"+"FlightArrivalAirportId");
                  GXUtil.WriteLogRaw("Old: ",Z23FlightArrivalAirportId);
                  GXUtil.WriteLogRaw("Current: ",T00064_A23FlightArrivalAirportId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Flight"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert067( )
      {
         BeforeValidate067( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable067( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM067( 0) ;
            CheckOptimisticConcurrency067( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm067( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert067( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000629 */
                     pr_default.execute(24, new Object[] {A33FlightPrice, A34FlightDiscountPercentage, n36AirlineId, A36AirlineId, A21FlightDepartureAirportId, A23FlightArrivalAirportId});
                     A20FlightId = T000629_A20FlightId[0];
                     AssignAttri("", false, "A20FlightId", StringUtil.LTrimStr( (decimal)(A20FlightId), 4, 0));
                     pr_default.close(24);
                     pr_default.SmartCacheProvider.SetUpdated("Flight");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel067( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption060( ) ;
                           }
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
               Load067( ) ;
            }
            EndLevel067( ) ;
         }
         CloseExtendedTableCursors067( ) ;
      }

      protected void Update067( )
      {
         BeforeValidate067( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable067( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency067( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm067( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate067( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000630 */
                     pr_default.execute(25, new Object[] {A33FlightPrice, A34FlightDiscountPercentage, n36AirlineId, A36AirlineId, A21FlightDepartureAirportId, A23FlightArrivalAirportId, A20FlightId});
                     pr_default.close(25);
                     pr_default.SmartCacheProvider.SetUpdated("Flight");
                     if ( (pr_default.getStatus(25) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Flight"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate067( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel067( ) ;
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey( ) ;
                              endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                              endTrnMsgCod = "SuccessfullyUpdated";
                              ResetCaption060( ) ;
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
            }
            EndLevel067( ) ;
         }
         CloseExtendedTableCursors067( ) ;
      }

      protected void DeferredUpdate067( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate067( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency067( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls067( ) ;
            AfterConfirm067( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete067( ) ;
               if ( AnyError == 0 )
               {
                  A40FlightCapacity = O40FlightCapacity;
                  n40FlightCapacity = false;
                  AssignAttri("", false, "A40FlightCapacity", StringUtil.LTrimStr( (decimal)(A40FlightCapacity), 4, 0));
                  ScanStart069( ) ;
                  while ( RcdFound9 != 0 )
                  {
                     getByPrimaryKey069( ) ;
                     Delete069( ) ;
                     ScanNext069( ) ;
                     O40FlightCapacity = A40FlightCapacity;
                     n40FlightCapacity = false;
                     AssignAttri("", false, "A40FlightCapacity", StringUtil.LTrimStr( (decimal)(A40FlightCapacity), 4, 0));
                  }
                  ScanEnd069( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000631 */
                     pr_default.execute(26, new Object[] {A20FlightId});
                     pr_default.close(26);
                     pr_default.SmartCacheProvider.SetUpdated("Flight");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        /* End of After( delete) rules */
                        if ( AnyError == 0 )
                        {
                           move_next( ) ;
                           if ( RcdFound7 == 0 )
                           {
                              InitAll067( ) ;
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
                           ResetCaption060( ) ;
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
         }
         sMode7 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel067( ) ;
         Gx_mode = sMode7;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls067( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000633 */
            pr_default.execute(27, new Object[] {A20FlightId});
            if ( (pr_default.getStatus(27) != 101) )
            {
               A40FlightCapacity = T000633_A40FlightCapacity[0];
               n40FlightCapacity = T000633_n40FlightCapacity[0];
               AssignAttri("", false, "A40FlightCapacity", StringUtil.LTrimStr( (decimal)(A40FlightCapacity), 4, 0));
            }
            else
            {
               A40FlightCapacity = 0;
               n40FlightCapacity = false;
               AssignAttri("", false, "A40FlightCapacity", StringUtil.LTrimStr( (decimal)(A40FlightCapacity), 4, 0));
            }
            pr_default.close(27);
            /* Using cursor T000634 */
            pr_default.execute(28, new Object[] {A21FlightDepartureAirportId});
            A22FlightDepartureAirportName = T000634_A22FlightDepartureAirportName[0];
            AssignAttri("", false, "A22FlightDepartureAirportName", A22FlightDepartureAirportName);
            A25FlightDepartureCountryId = T000634_A25FlightDepartureCountryId[0];
            AssignAttri("", false, "A25FlightDepartureCountryId", StringUtil.LTrimStr( (decimal)(A25FlightDepartureCountryId), 4, 0));
            A27FlightDepartureCityId = T000634_A27FlightDepartureCityId[0];
            AssignAttri("", false, "A27FlightDepartureCityId", StringUtil.LTrimStr( (decimal)(A27FlightDepartureCityId), 4, 0));
            pr_default.close(28);
            /* Using cursor T000635 */
            pr_default.execute(29, new Object[] {A25FlightDepartureCountryId});
            A26FlightDepartureCountryName = T000635_A26FlightDepartureCountryName[0];
            AssignAttri("", false, "A26FlightDepartureCountryName", A26FlightDepartureCountryName);
            pr_default.close(29);
            /* Using cursor T000636 */
            pr_default.execute(30, new Object[] {A25FlightDepartureCountryId, A27FlightDepartureCityId});
            A28FlightDepartureCityName = T000636_A28FlightDepartureCityName[0];
            AssignAttri("", false, "A28FlightDepartureCityName", A28FlightDepartureCityName);
            pr_default.close(30);
            /* Using cursor T000637 */
            pr_default.execute(31, new Object[] {A23FlightArrivalAirportId});
            A24FlightArrivalAirportName = T000637_A24FlightArrivalAirportName[0];
            AssignAttri("", false, "A24FlightArrivalAirportName", A24FlightArrivalAirportName);
            A29FlightArrivalCountryId = T000637_A29FlightArrivalCountryId[0];
            AssignAttri("", false, "A29FlightArrivalCountryId", StringUtil.LTrimStr( (decimal)(A29FlightArrivalCountryId), 4, 0));
            A31FlightArrivalCityId = T000637_A31FlightArrivalCityId[0];
            AssignAttri("", false, "A31FlightArrivalCityId", StringUtil.LTrimStr( (decimal)(A31FlightArrivalCityId), 4, 0));
            pr_default.close(31);
            /* Using cursor T000638 */
            pr_default.execute(32, new Object[] {A29FlightArrivalCountryId});
            A30FlightArrivalCountryName = T000638_A30FlightArrivalCountryName[0];
            AssignAttri("", false, "A30FlightArrivalCountryName", A30FlightArrivalCountryName);
            pr_default.close(32);
            /* Using cursor T000639 */
            pr_default.execute(33, new Object[] {A29FlightArrivalCountryId, A31FlightArrivalCityId});
            A32FlightArrivalCityName = T000639_A32FlightArrivalCityName[0];
            AssignAttri("", false, "A32FlightArrivalCityName", A32FlightArrivalCityName);
            pr_default.close(33);
            /* Using cursor T000640 */
            pr_default.execute(34, new Object[] {n36AirlineId, A36AirlineId});
            A37AirlineName = T000640_A37AirlineName[0];
            AssignAttri("", false, "A37AirlineName", A37AirlineName);
            A38AirlineDiscountPercentage = T000640_A38AirlineDiscountPercentage[0];
            AssignAttri("", false, "A38AirlineDiscountPercentage", StringUtil.LTrimStr( (decimal)(A38AirlineDiscountPercentage), 3, 0));
            pr_default.close(34);
            if ( A38AirlineDiscountPercentage > A34FlightDiscountPercentage )
            {
               A35FlightFinalPrice = (decimal)(A33FlightPrice*(1-A38AirlineDiscountPercentage/ (decimal)(100)));
               AssignAttri("", false, "A35FlightFinalPrice", StringUtil.LTrimStr( A35FlightFinalPrice, 9, 2));
            }
            else
            {
               A35FlightFinalPrice = (decimal)(A33FlightPrice*(1-A34FlightDiscountPercentage/ (decimal)(100)));
               AssignAttri("", false, "A35FlightFinalPrice", StringUtil.LTrimStr( A35FlightFinalPrice, 9, 2));
            }
         }
      }

      protected void ProcessNestedLevel069( )
      {
         s40FlightCapacity = O40FlightCapacity;
         n40FlightCapacity = false;
         AssignAttri("", false, "A40FlightCapacity", StringUtil.LTrimStr( (decimal)(A40FlightCapacity), 4, 0));
         nGXsfl_138_idx = 0;
         while ( nGXsfl_138_idx < nRC_GXsfl_138 )
         {
            ReadRow069( ) ;
            if ( ( nRcdExists_9 != 0 ) || ( nIsMod_9 != 0 ) )
            {
               standaloneNotModal069( ) ;
               GetKey069( ) ;
               if ( ( nRcdExists_9 == 0 ) && ( nRcdDeleted_9 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert069( ) ;
               }
               else
               {
                  if ( RcdFound9 != 0 )
                  {
                     if ( ( nRcdDeleted_9 != 0 ) && ( nRcdExists_9 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete069( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_9 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update069( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_9 == 0 )
                     {
                        GXCCtl = "FLIGHTSEATID_" + sGXsfl_138_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtFlightSeatId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
               O40FlightCapacity = A40FlightCapacity;
               n40FlightCapacity = false;
               AssignAttri("", false, "A40FlightCapacity", StringUtil.LTrimStr( (decimal)(A40FlightCapacity), 4, 0));
            }
            ChangePostValue( edtFlightSeatId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A41FlightSeatId), 4, 0, ".", ""))) ;
            ChangePostValue( cmbFlightSeatChar_Internalname, StringUtil.RTrim( A42FlightSeatChar)) ;
            ChangePostValue( cmbFlightSeatLocation_Internalname, StringUtil.RTrim( A43FlightSeatLocation)) ;
            ChangePostValue( "ZT_"+"Z41FlightSeatId_"+sGXsfl_138_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z41FlightSeatId), 4, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z42FlightSeatChar_"+sGXsfl_138_idx, StringUtil.RTrim( Z42FlightSeatChar)) ;
            ChangePostValue( "ZT_"+"Z43FlightSeatLocation_"+sGXsfl_138_idx, StringUtil.RTrim( Z43FlightSeatLocation)) ;
            ChangePostValue( "nRcdDeleted_9_"+sGXsfl_138_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_9), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_9_"+sGXsfl_138_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_9), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_9_"+sGXsfl_138_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_9), 4, 0, ".", ""))) ;
            if ( nIsMod_9 != 0 )
            {
               ChangePostValue( "FLIGHTSEATID_"+sGXsfl_138_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtFlightSeatId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "FLIGHTSEATCHAR_"+sGXsfl_138_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbFlightSeatChar.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "FLIGHTSEATLOCATION_"+sGXsfl_138_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbFlightSeatLocation.Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         if ( A40FlightCapacity < 8 )
         {
            GX_msglist.addItem("The seat quantity mustn`t be less than eight", 1, "");
            AnyError = 1;
         }
         /* End of After( level) rules */
         InitAll069( ) ;
         if ( AnyError != 0 )
         {
            O40FlightCapacity = s40FlightCapacity;
            n40FlightCapacity = false;
            AssignAttri("", false, "A40FlightCapacity", StringUtil.LTrimStr( (decimal)(A40FlightCapacity), 4, 0));
         }
         nRcdExists_9 = 0;
         nIsMod_9 = 0;
         nRcdDeleted_9 = 0;
      }

      protected void ProcessLevel067( )
      {
         /* Save parent mode. */
         sMode7 = Gx_mode;
         ProcessNestedLevel069( ) ;
         if ( AnyError != 0 )
         {
            O40FlightCapacity = s40FlightCapacity;
            n40FlightCapacity = false;
            AssignAttri("", false, "A40FlightCapacity", StringUtil.LTrimStr( (decimal)(A40FlightCapacity), 4, 0));
         }
         /* Restore parent mode. */
         Gx_mode = sMode7;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel067( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(2);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete067( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(3);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(34);
            pr_default.close(28);
            pr_default.close(31);
            pr_default.close(29);
            pr_default.close(30);
            pr_default.close(32);
            pr_default.close(33);
            pr_default.close(27);
            context.CommitDataStores("flight",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues060( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(3);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(34);
            pr_default.close(28);
            pr_default.close(31);
            pr_default.close(29);
            pr_default.close(30);
            pr_default.close(32);
            pr_default.close(33);
            pr_default.close(27);
            context.RollbackDataStores("flight",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart067( )
      {
         /* Using cursor T000641 */
         pr_default.execute(35);
         RcdFound7 = 0;
         if ( (pr_default.getStatus(35) != 101) )
         {
            RcdFound7 = 1;
            A20FlightId = T000641_A20FlightId[0];
            AssignAttri("", false, "A20FlightId", StringUtil.LTrimStr( (decimal)(A20FlightId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext067( )
      {
         /* Scan next routine */
         pr_default.readNext(35);
         RcdFound7 = 0;
         if ( (pr_default.getStatus(35) != 101) )
         {
            RcdFound7 = 1;
            A20FlightId = T000641_A20FlightId[0];
            AssignAttri("", false, "A20FlightId", StringUtil.LTrimStr( (decimal)(A20FlightId), 4, 0));
         }
      }

      protected void ScanEnd067( )
      {
         pr_default.close(35);
      }

      protected void AfterConfirm067( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert067( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate067( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete067( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete067( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate067( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes067( )
      {
         edtFlightId_Enabled = 0;
         AssignProp("", false, edtFlightId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFlightId_Enabled), 5, 0), true);
         edtFlightDepartureAirportId_Enabled = 0;
         AssignProp("", false, edtFlightDepartureAirportId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFlightDepartureAirportId_Enabled), 5, 0), true);
         edtFlightDepartureAirportName_Enabled = 0;
         AssignProp("", false, edtFlightDepartureAirportName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFlightDepartureAirportName_Enabled), 5, 0), true);
         edtFlightDepartureCountryId_Enabled = 0;
         AssignProp("", false, edtFlightDepartureCountryId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFlightDepartureCountryId_Enabled), 5, 0), true);
         edtFlightDepartureCountryName_Enabled = 0;
         AssignProp("", false, edtFlightDepartureCountryName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFlightDepartureCountryName_Enabled), 5, 0), true);
         edtFlightDepartureCityId_Enabled = 0;
         AssignProp("", false, edtFlightDepartureCityId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFlightDepartureCityId_Enabled), 5, 0), true);
         edtFlightDepartureCityName_Enabled = 0;
         AssignProp("", false, edtFlightDepartureCityName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFlightDepartureCityName_Enabled), 5, 0), true);
         edtFlightArrivalAirportId_Enabled = 0;
         AssignProp("", false, edtFlightArrivalAirportId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFlightArrivalAirportId_Enabled), 5, 0), true);
         edtFlightArrivalAirportName_Enabled = 0;
         AssignProp("", false, edtFlightArrivalAirportName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFlightArrivalAirportName_Enabled), 5, 0), true);
         edtFlightArrivalCountryId_Enabled = 0;
         AssignProp("", false, edtFlightArrivalCountryId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFlightArrivalCountryId_Enabled), 5, 0), true);
         edtFlightArrivalCountryName_Enabled = 0;
         AssignProp("", false, edtFlightArrivalCountryName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFlightArrivalCountryName_Enabled), 5, 0), true);
         edtFlightArrivalCityId_Enabled = 0;
         AssignProp("", false, edtFlightArrivalCityId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFlightArrivalCityId_Enabled), 5, 0), true);
         edtFlightArrivalCityName_Enabled = 0;
         AssignProp("", false, edtFlightArrivalCityName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFlightArrivalCityName_Enabled), 5, 0), true);
         edtFlightPrice_Enabled = 0;
         AssignProp("", false, edtFlightPrice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFlightPrice_Enabled), 5, 0), true);
         edtFlightDiscountPercentage_Enabled = 0;
         AssignProp("", false, edtFlightDiscountPercentage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFlightDiscountPercentage_Enabled), 5, 0), true);
         edtAirlineId_Enabled = 0;
         AssignProp("", false, edtAirlineId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAirlineId_Enabled), 5, 0), true);
         edtAirlineName_Enabled = 0;
         AssignProp("", false, edtAirlineName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAirlineName_Enabled), 5, 0), true);
         edtAirlineDiscountPercentage_Enabled = 0;
         AssignProp("", false, edtAirlineDiscountPercentage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAirlineDiscountPercentage_Enabled), 5, 0), true);
         edtFlightFinalPrice_Enabled = 0;
         AssignProp("", false, edtFlightFinalPrice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFlightFinalPrice_Enabled), 5, 0), true);
         edtFlightCapacity_Enabled = 0;
         AssignProp("", false, edtFlightCapacity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFlightCapacity_Enabled), 5, 0), true);
      }

      protected void ZM069( short GX_JID )
      {
         if ( ( GX_JID == 15 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z43FlightSeatLocation = T00063_A43FlightSeatLocation[0];
            }
            else
            {
               Z43FlightSeatLocation = A43FlightSeatLocation;
            }
         }
         if ( GX_JID == -15 )
         {
            Z20FlightId = A20FlightId;
            Z41FlightSeatId = A41FlightSeatId;
            Z42FlightSeatChar = A42FlightSeatChar;
            Z43FlightSeatLocation = A43FlightSeatLocation;
         }
      }

      protected void standaloneNotModal069( )
      {
      }

      protected void standaloneModal069( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtFlightSeatId_Enabled = 0;
            AssignProp("", false, edtFlightSeatId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFlightSeatId_Enabled), 5, 0), !bGXsfl_138_Refreshing);
         }
         else
         {
            edtFlightSeatId_Enabled = 1;
            AssignProp("", false, edtFlightSeatId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFlightSeatId_Enabled), 5, 0), !bGXsfl_138_Refreshing);
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            cmbFlightSeatChar.Enabled = 0;
            AssignProp("", false, cmbFlightSeatChar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbFlightSeatChar.Enabled), 5, 0), !bGXsfl_138_Refreshing);
         }
         else
         {
            cmbFlightSeatChar.Enabled = 1;
            AssignProp("", false, cmbFlightSeatChar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbFlightSeatChar.Enabled), 5, 0), !bGXsfl_138_Refreshing);
         }
      }

      protected void Load069( )
      {
         /* Using cursor T000642 */
         pr_default.execute(36, new Object[] {A20FlightId, A41FlightSeatId, A42FlightSeatChar});
         if ( (pr_default.getStatus(36) != 101) )
         {
            RcdFound9 = 1;
            A43FlightSeatLocation = T000642_A43FlightSeatLocation[0];
            ZM069( -15) ;
         }
         pr_default.close(36);
         OnLoadActions069( ) ;
      }

      protected void OnLoadActions069( )
      {
         if ( IsIns( )  )
         {
            A40FlightCapacity = (short)(O40FlightCapacity+1);
            n40FlightCapacity = false;
            AssignAttri("", false, "A40FlightCapacity", StringUtil.LTrimStr( (decimal)(A40FlightCapacity), 4, 0));
         }
         else
         {
            if ( IsUpd( )  )
            {
               A40FlightCapacity = O40FlightCapacity;
               n40FlightCapacity = false;
               AssignAttri("", false, "A40FlightCapacity", StringUtil.LTrimStr( (decimal)(A40FlightCapacity), 4, 0));
            }
            else
            {
               if ( IsDlt( )  )
               {
                  A40FlightCapacity = (short)(O40FlightCapacity-1);
                  n40FlightCapacity = false;
                  AssignAttri("", false, "A40FlightCapacity", StringUtil.LTrimStr( (decimal)(A40FlightCapacity), 4, 0));
               }
            }
         }
      }

      protected void CheckExtendedTable069( )
      {
         nIsDirty_9 = 0;
         Gx_BScreen = 1;
         standaloneModal069( ) ;
         if ( ! ( ( StringUtil.StrCmp(A42FlightSeatChar, "A") == 0 ) || ( StringUtil.StrCmp(A42FlightSeatChar, "B") == 0 ) || ( StringUtil.StrCmp(A42FlightSeatChar, "C") == 0 ) || ( StringUtil.StrCmp(A42FlightSeatChar, "D") == 0 ) || ( StringUtil.StrCmp(A42FlightSeatChar, "E") == 0 ) || ( StringUtil.StrCmp(A42FlightSeatChar, "F") == 0 ) ) )
         {
            GXCCtl = "FLIGHTSEATCHAR_" + sGXsfl_138_idx;
            GX_msglist.addItem("Field Flight Seat Char is out of range", "OutOfRange", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = cmbFlightSeatChar_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( StringUtil.StrCmp(A43FlightSeatLocation, "W") == 0 ) || ( StringUtil.StrCmp(A43FlightSeatLocation, "M") == 0 ) || ( StringUtil.StrCmp(A43FlightSeatLocation, "A") == 0 ) ) )
         {
            GXCCtl = "FLIGHTSEATLOCATION_" + sGXsfl_138_idx;
            GX_msglist.addItem("Field Flight Seat Location is out of range", "OutOfRange", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = cmbFlightSeatLocation_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( IsIns( )  )
         {
            nIsDirty_9 = 1;
            A40FlightCapacity = (short)(O40FlightCapacity+1);
            n40FlightCapacity = false;
            AssignAttri("", false, "A40FlightCapacity", StringUtil.LTrimStr( (decimal)(A40FlightCapacity), 4, 0));
         }
         else
         {
            if ( IsUpd( )  )
            {
               nIsDirty_9 = 1;
               A40FlightCapacity = O40FlightCapacity;
               n40FlightCapacity = false;
               AssignAttri("", false, "A40FlightCapacity", StringUtil.LTrimStr( (decimal)(A40FlightCapacity), 4, 0));
            }
            else
            {
               if ( IsDlt( )  )
               {
                  nIsDirty_9 = 1;
                  A40FlightCapacity = (short)(O40FlightCapacity-1);
                  n40FlightCapacity = false;
                  AssignAttri("", false, "A40FlightCapacity", StringUtil.LTrimStr( (decimal)(A40FlightCapacity), 4, 0));
               }
            }
         }
      }

      protected void CloseExtendedTableCursors069( )
      {
      }

      protected void enableDisable069( )
      {
      }

      protected void GetKey069( )
      {
         /* Using cursor T000643 */
         pr_default.execute(37, new Object[] {A20FlightId, A41FlightSeatId, A42FlightSeatChar});
         if ( (pr_default.getStatus(37) != 101) )
         {
            RcdFound9 = 1;
         }
         else
         {
            RcdFound9 = 0;
         }
         pr_default.close(37);
      }

      protected void getByPrimaryKey069( )
      {
         /* Using cursor T00063 */
         pr_default.execute(1, new Object[] {A20FlightId, A41FlightSeatId, A42FlightSeatChar});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM069( 15) ;
            RcdFound9 = 1;
            InitializeNonKey069( ) ;
            A41FlightSeatId = T00063_A41FlightSeatId[0];
            A42FlightSeatChar = T00063_A42FlightSeatChar[0];
            A43FlightSeatLocation = T00063_A43FlightSeatLocation[0];
            Z20FlightId = A20FlightId;
            Z41FlightSeatId = A41FlightSeatId;
            Z42FlightSeatChar = A42FlightSeatChar;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal069( ) ;
            Load069( ) ;
            Gx_mode = sMode9;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound9 = 0;
            InitializeNonKey069( ) ;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal069( ) ;
            Gx_mode = sMode9;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes069( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency069( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00062 */
            pr_default.execute(0, new Object[] {A20FlightId, A41FlightSeatId, A42FlightSeatChar});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"FlightSeat"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z43FlightSeatLocation, T00062_A43FlightSeatLocation[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z43FlightSeatLocation, T00062_A43FlightSeatLocation[0]) != 0 )
               {
                  GXUtil.WriteLog("flight:[seudo value changed for attri]"+"FlightSeatLocation");
                  GXUtil.WriteLogRaw("Old: ",Z43FlightSeatLocation);
                  GXUtil.WriteLogRaw("Current: ",T00062_A43FlightSeatLocation[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"FlightSeat"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert069( )
      {
         BeforeValidate069( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable069( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM069( 0) ;
            CheckOptimisticConcurrency069( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm069( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert069( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000644 */
                     pr_default.execute(38, new Object[] {A20FlightId, A41FlightSeatId, A42FlightSeatChar, A43FlightSeatLocation});
                     pr_default.close(38);
                     pr_default.SmartCacheProvider.SetUpdated("FlightSeat");
                     if ( (pr_default.getStatus(38) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
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
               Load069( ) ;
            }
            EndLevel069( ) ;
         }
         CloseExtendedTableCursors069( ) ;
      }

      protected void Update069( )
      {
         BeforeValidate069( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable069( ) ;
         }
         if ( ( nIsMod_9 != 0 ) || ( nIsDirty_9 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency069( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm069( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate069( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000645 */
                        pr_default.execute(39, new Object[] {A43FlightSeatLocation, A20FlightId, A41FlightSeatId, A42FlightSeatChar});
                        pr_default.close(39);
                        pr_default.SmartCacheProvider.SetUpdated("FlightSeat");
                        if ( (pr_default.getStatus(39) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"FlightSeat"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate069( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey069( ) ;
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
               EndLevel069( ) ;
            }
         }
         CloseExtendedTableCursors069( ) ;
      }

      protected void DeferredUpdate069( )
      {
      }

      protected void Delete069( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate069( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency069( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls069( ) ;
            AfterConfirm069( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete069( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000646 */
                  pr_default.execute(40, new Object[] {A20FlightId, A41FlightSeatId, A42FlightSeatChar});
                  pr_default.close(40);
                  pr_default.SmartCacheProvider.SetUpdated("FlightSeat");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode9 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel069( ) ;
         Gx_mode = sMode9;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls069( )
      {
         standaloneModal069( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            if ( IsIns( )  )
            {
               A40FlightCapacity = (short)(O40FlightCapacity+1);
               n40FlightCapacity = false;
               AssignAttri("", false, "A40FlightCapacity", StringUtil.LTrimStr( (decimal)(A40FlightCapacity), 4, 0));
            }
            else
            {
               if ( IsUpd( )  )
               {
                  A40FlightCapacity = O40FlightCapacity;
                  n40FlightCapacity = false;
                  AssignAttri("", false, "A40FlightCapacity", StringUtil.LTrimStr( (decimal)(A40FlightCapacity), 4, 0));
               }
               else
               {
                  if ( IsDlt( )  )
                  {
                     A40FlightCapacity = (short)(O40FlightCapacity-1);
                     n40FlightCapacity = false;
                     AssignAttri("", false, "A40FlightCapacity", StringUtil.LTrimStr( (decimal)(A40FlightCapacity), 4, 0));
                  }
               }
            }
         }
      }

      protected void EndLevel069( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart069( )
      {
         /* Scan By routine */
         /* Using cursor T000647 */
         pr_default.execute(41, new Object[] {A20FlightId});
         RcdFound9 = 0;
         if ( (pr_default.getStatus(41) != 101) )
         {
            RcdFound9 = 1;
            A41FlightSeatId = T000647_A41FlightSeatId[0];
            A42FlightSeatChar = T000647_A42FlightSeatChar[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext069( )
      {
         /* Scan next routine */
         pr_default.readNext(41);
         RcdFound9 = 0;
         if ( (pr_default.getStatus(41) != 101) )
         {
            RcdFound9 = 1;
            A41FlightSeatId = T000647_A41FlightSeatId[0];
            A42FlightSeatChar = T000647_A42FlightSeatChar[0];
         }
      }

      protected void ScanEnd069( )
      {
         pr_default.close(41);
      }

      protected void AfterConfirm069( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert069( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate069( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete069( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete069( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate069( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes069( )
      {
         edtFlightSeatId_Enabled = 0;
         AssignProp("", false, edtFlightSeatId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFlightSeatId_Enabled), 5, 0), !bGXsfl_138_Refreshing);
         cmbFlightSeatChar.Enabled = 0;
         AssignProp("", false, cmbFlightSeatChar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbFlightSeatChar.Enabled), 5, 0), !bGXsfl_138_Refreshing);
         cmbFlightSeatLocation.Enabled = 0;
         AssignProp("", false, cmbFlightSeatLocation_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbFlightSeatLocation.Enabled), 5, 0), !bGXsfl_138_Refreshing);
      }

      protected void send_integrity_lvl_hashes069( )
      {
      }

      protected void send_integrity_lvl_hashes067( )
      {
      }

      protected void SubsflControlProps_1389( )
      {
         edtFlightSeatId_Internalname = "FLIGHTSEATID_"+sGXsfl_138_idx;
         cmbFlightSeatChar_Internalname = "FLIGHTSEATCHAR_"+sGXsfl_138_idx;
         cmbFlightSeatLocation_Internalname = "FLIGHTSEATLOCATION_"+sGXsfl_138_idx;
      }

      protected void SubsflControlProps_fel_1389( )
      {
         edtFlightSeatId_Internalname = "FLIGHTSEATID_"+sGXsfl_138_fel_idx;
         cmbFlightSeatChar_Internalname = "FLIGHTSEATCHAR_"+sGXsfl_138_fel_idx;
         cmbFlightSeatLocation_Internalname = "FLIGHTSEATLOCATION_"+sGXsfl_138_fel_idx;
      }

      protected void AddRow069( )
      {
         nGXsfl_138_idx = (int)(nGXsfl_138_idx+1);
         sGXsfl_138_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_138_idx), 4, 0), 4, "0");
         SubsflControlProps_1389( ) ;
         SendRow069( ) ;
      }

      protected void SendRow069( )
      {
         Gridflight_seatRow = GXWebRow.GetNew(context);
         if ( subGridflight_seat_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridflight_seat_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridflight_seat_Class, "") != 0 )
            {
               subGridflight_seat_Linesclass = subGridflight_seat_Class+"Odd";
            }
         }
         else if ( subGridflight_seat_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridflight_seat_Backstyle = 0;
            subGridflight_seat_Backcolor = subGridflight_seat_Allbackcolor;
            if ( StringUtil.StrCmp(subGridflight_seat_Class, "") != 0 )
            {
               subGridflight_seat_Linesclass = subGridflight_seat_Class+"Uniform";
            }
         }
         else if ( subGridflight_seat_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridflight_seat_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridflight_seat_Class, "") != 0 )
            {
               subGridflight_seat_Linesclass = subGridflight_seat_Class+"Odd";
            }
            subGridflight_seat_Backcolor = (int)(0x0);
         }
         else if ( subGridflight_seat_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridflight_seat_Backstyle = 1;
            if ( ((int)((nGXsfl_138_idx) % (2))) == 0 )
            {
               subGridflight_seat_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridflight_seat_Class, "") != 0 )
               {
                  subGridflight_seat_Linesclass = subGridflight_seat_Class+"Even";
               }
            }
            else
            {
               subGridflight_seat_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridflight_seat_Class, "") != 0 )
               {
                  subGridflight_seat_Linesclass = subGridflight_seat_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_9_" + sGXsfl_138_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 139,'',false,'" + sGXsfl_138_idx + "',138)\"";
         ROClassString = "Attribute";
         Gridflight_seatRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFlightSeatId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A41FlightSeatId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A41FlightSeatId), "ZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,139);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtFlightSeatId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtFlightSeatId_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)138,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_9_" + sGXsfl_138_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 140,'',false,'" + sGXsfl_138_idx + "',138)\"";
         GXCCtl = "FLIGHTSEATCHAR_" + sGXsfl_138_idx;
         cmbFlightSeatChar.Name = GXCCtl;
         cmbFlightSeatChar.WebTags = "";
         cmbFlightSeatChar.addItem("A", "A", 0);
         cmbFlightSeatChar.addItem("B", "B", 0);
         cmbFlightSeatChar.addItem("C", "C", 0);
         cmbFlightSeatChar.addItem("D", "D", 0);
         cmbFlightSeatChar.addItem("E", "E", 0);
         cmbFlightSeatChar.addItem("F", "F", 0);
         if ( cmbFlightSeatChar.ItemCount > 0 )
         {
            A42FlightSeatChar = cmbFlightSeatChar.getValidValue(A42FlightSeatChar);
         }
         /* ComboBox */
         Gridflight_seatRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbFlightSeatChar,(string)cmbFlightSeatChar_Internalname,StringUtil.RTrim( A42FlightSeatChar),(short)1,(string)cmbFlightSeatChar_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,cmbFlightSeatChar.Enabled,(short)1,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,140);\"",(string)"",(bool)true,(short)0});
         cmbFlightSeatChar.CurrentValue = StringUtil.RTrim( A42FlightSeatChar);
         AssignProp("", false, cmbFlightSeatChar_Internalname, "Values", (string)(cmbFlightSeatChar.ToJavascriptSource()), !bGXsfl_138_Refreshing);
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_9_" + sGXsfl_138_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 141,'',false,'" + sGXsfl_138_idx + "',138)\"";
         if ( ( cmbFlightSeatLocation.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "FLIGHTSEATLOCATION_" + sGXsfl_138_idx;
            cmbFlightSeatLocation.Name = GXCCtl;
            cmbFlightSeatLocation.WebTags = "";
            cmbFlightSeatLocation.addItem("W", "Window", 0);
            cmbFlightSeatLocation.addItem("M", "Middle", 0);
            cmbFlightSeatLocation.addItem("A", "Aisle", 0);
            if ( cmbFlightSeatLocation.ItemCount > 0 )
            {
               A43FlightSeatLocation = cmbFlightSeatLocation.getValidValue(A43FlightSeatLocation);
            }
         }
         /* ComboBox */
         Gridflight_seatRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbFlightSeatLocation,(string)cmbFlightSeatLocation_Internalname,StringUtil.RTrim( A43FlightSeatLocation),(short)1,(string)cmbFlightSeatLocation_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,cmbFlightSeatLocation.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,141);\"",(string)"",(bool)true,(short)0});
         cmbFlightSeatLocation.CurrentValue = StringUtil.RTrim( A43FlightSeatLocation);
         AssignProp("", false, cmbFlightSeatLocation_Internalname, "Values", (string)(cmbFlightSeatLocation.ToJavascriptSource()), !bGXsfl_138_Refreshing);
         ajax_sending_grid_row(Gridflight_seatRow);
         send_integrity_lvl_hashes069( ) ;
         GXCCtl = "Z41FlightSeatId_" + sGXsfl_138_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z41FlightSeatId), 4, 0, ".", "")));
         GXCCtl = "Z42FlightSeatChar_" + sGXsfl_138_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z42FlightSeatChar));
         GXCCtl = "Z43FlightSeatLocation_" + sGXsfl_138_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z43FlightSeatLocation));
         GXCCtl = "nRcdDeleted_9_" + sGXsfl_138_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_9), 4, 0, ".", "")));
         GXCCtl = "nRcdExists_9_" + sGXsfl_138_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_9), 4, 0, ".", "")));
         GXCCtl = "nIsMod_9_" + sGXsfl_138_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_9), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "FLIGHTSEATID_"+sGXsfl_138_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtFlightSeatId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "FLIGHTSEATCHAR_"+sGXsfl_138_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbFlightSeatChar.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "FLIGHTSEATLOCATION_"+sGXsfl_138_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbFlightSeatLocation.Enabled), 5, 0, ".", "")));
         ajax_sending_grid_row(null);
         Gridflight_seatContainer.AddRow(Gridflight_seatRow);
      }

      protected void ReadRow069( )
      {
         nGXsfl_138_idx = (int)(nGXsfl_138_idx+1);
         sGXsfl_138_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_138_idx), 4, 0), 4, "0");
         SubsflControlProps_1389( ) ;
         edtFlightSeatId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "FLIGHTSEATID_"+sGXsfl_138_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         cmbFlightSeatChar.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "FLIGHTSEATCHAR_"+sGXsfl_138_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         cmbFlightSeatLocation.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "FLIGHTSEATLOCATION_"+sGXsfl_138_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         if ( ( ( context.localUtil.CToN( cgiGet( edtFlightSeatId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtFlightSeatId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "FLIGHTSEATID_" + sGXsfl_138_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtFlightSeatId_Internalname;
            wbErr = true;
            A41FlightSeatId = 0;
         }
         else
         {
            A41FlightSeatId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtFlightSeatId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
         }
         cmbFlightSeatChar.Name = cmbFlightSeatChar_Internalname;
         cmbFlightSeatChar.CurrentValue = cgiGet( cmbFlightSeatChar_Internalname);
         A42FlightSeatChar = cgiGet( cmbFlightSeatChar_Internalname);
         cmbFlightSeatLocation.Name = cmbFlightSeatLocation_Internalname;
         cmbFlightSeatLocation.CurrentValue = cgiGet( cmbFlightSeatLocation_Internalname);
         A43FlightSeatLocation = cgiGet( cmbFlightSeatLocation_Internalname);
         GXCCtl = "Z41FlightSeatId_" + sGXsfl_138_idx;
         Z41FlightSeatId = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "Z42FlightSeatChar_" + sGXsfl_138_idx;
         Z42FlightSeatChar = cgiGet( GXCCtl);
         GXCCtl = "Z43FlightSeatLocation_" + sGXsfl_138_idx;
         Z43FlightSeatLocation = cgiGet( GXCCtl);
         GXCCtl = "nRcdDeleted_9_" + sGXsfl_138_idx;
         nRcdDeleted_9 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_9_" + sGXsfl_138_idx;
         nRcdExists_9 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_9_" + sGXsfl_138_idx;
         nIsMod_9 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defcmbFlightSeatChar_Enabled = cmbFlightSeatChar.Enabled;
         defedtFlightSeatId_Enabled = edtFlightSeatId_Enabled;
      }

      protected void ConfirmValues060( )
      {
         nGXsfl_138_idx = 0;
         sGXsfl_138_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_138_idx), 4, 0), 4, "0");
         SubsflControlProps_1389( ) ;
         while ( nGXsfl_138_idx < nRC_GXsfl_138 )
         {
            nGXsfl_138_idx = (int)(nGXsfl_138_idx+1);
            sGXsfl_138_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_138_idx), 4, 0), 4, "0");
            SubsflControlProps_1389( ) ;
            ChangePostValue( "Z41FlightSeatId_"+sGXsfl_138_idx, cgiGet( "ZT_"+"Z41FlightSeatId_"+sGXsfl_138_idx)) ;
            DeletePostValue( "ZT_"+"Z41FlightSeatId_"+sGXsfl_138_idx) ;
            ChangePostValue( "Z42FlightSeatChar_"+sGXsfl_138_idx, cgiGet( "ZT_"+"Z42FlightSeatChar_"+sGXsfl_138_idx)) ;
            DeletePostValue( "ZT_"+"Z42FlightSeatChar_"+sGXsfl_138_idx) ;
            ChangePostValue( "Z43FlightSeatLocation_"+sGXsfl_138_idx, cgiGet( "ZT_"+"Z43FlightSeatLocation_"+sGXsfl_138_idx)) ;
            DeletePostValue( "ZT_"+"Z43FlightSeatLocation_"+sGXsfl_138_idx) ;
         }
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("flight.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z20FlightId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z20FlightId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z33FlightPrice", StringUtil.LTrim( StringUtil.NToC( Z33FlightPrice, 9, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z34FlightDiscountPercentage", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z34FlightDiscountPercentage), 3, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z36AirlineId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z36AirlineId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z21FlightDepartureAirportId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z21FlightDepartureAirportId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z23FlightArrivalAirportId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z23FlightArrivalAirportId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "O40FlightCapacity", StringUtil.LTrim( StringUtil.NToC( (decimal)(O40FlightCapacity), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_138", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_138_idx), 8, 0, ".", "")));
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
         return formatLink("flight.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Flight" ;
      }

      public override string GetPgmdesc( )
      {
         return "Flight" ;
      }

      protected void InitializeNonKey067( )
      {
         A35FlightFinalPrice = 0;
         AssignAttri("", false, "A35FlightFinalPrice", StringUtil.LTrimStr( A35FlightFinalPrice, 9, 2));
         A21FlightDepartureAirportId = 0;
         AssignAttri("", false, "A21FlightDepartureAirportId", StringUtil.LTrimStr( (decimal)(A21FlightDepartureAirportId), 4, 0));
         A22FlightDepartureAirportName = "";
         AssignAttri("", false, "A22FlightDepartureAirportName", A22FlightDepartureAirportName);
         A25FlightDepartureCountryId = 0;
         AssignAttri("", false, "A25FlightDepartureCountryId", StringUtil.LTrimStr( (decimal)(A25FlightDepartureCountryId), 4, 0));
         A26FlightDepartureCountryName = "";
         AssignAttri("", false, "A26FlightDepartureCountryName", A26FlightDepartureCountryName);
         A27FlightDepartureCityId = 0;
         AssignAttri("", false, "A27FlightDepartureCityId", StringUtil.LTrimStr( (decimal)(A27FlightDepartureCityId), 4, 0));
         A28FlightDepartureCityName = "";
         AssignAttri("", false, "A28FlightDepartureCityName", A28FlightDepartureCityName);
         A23FlightArrivalAirportId = 0;
         AssignAttri("", false, "A23FlightArrivalAirportId", StringUtil.LTrimStr( (decimal)(A23FlightArrivalAirportId), 4, 0));
         A24FlightArrivalAirportName = "";
         AssignAttri("", false, "A24FlightArrivalAirportName", A24FlightArrivalAirportName);
         A29FlightArrivalCountryId = 0;
         AssignAttri("", false, "A29FlightArrivalCountryId", StringUtil.LTrimStr( (decimal)(A29FlightArrivalCountryId), 4, 0));
         A30FlightArrivalCountryName = "";
         AssignAttri("", false, "A30FlightArrivalCountryName", A30FlightArrivalCountryName);
         A31FlightArrivalCityId = 0;
         AssignAttri("", false, "A31FlightArrivalCityId", StringUtil.LTrimStr( (decimal)(A31FlightArrivalCityId), 4, 0));
         A32FlightArrivalCityName = "";
         AssignAttri("", false, "A32FlightArrivalCityName", A32FlightArrivalCityName);
         A33FlightPrice = 0;
         AssignAttri("", false, "A33FlightPrice", StringUtil.LTrimStr( A33FlightPrice, 9, 2));
         A34FlightDiscountPercentage = 0;
         AssignAttri("", false, "A34FlightDiscountPercentage", StringUtil.LTrimStr( (decimal)(A34FlightDiscountPercentage), 3, 0));
         A36AirlineId = 0;
         n36AirlineId = false;
         AssignAttri("", false, "A36AirlineId", StringUtil.LTrimStr( (decimal)(A36AirlineId), 4, 0));
         n36AirlineId = ((0==A36AirlineId) ? true : false);
         A37AirlineName = "";
         AssignAttri("", false, "A37AirlineName", A37AirlineName);
         A38AirlineDiscountPercentage = 0;
         AssignAttri("", false, "A38AirlineDiscountPercentage", StringUtil.LTrimStr( (decimal)(A38AirlineDiscountPercentage), 3, 0));
         A40FlightCapacity = 0;
         n40FlightCapacity = false;
         AssignAttri("", false, "A40FlightCapacity", StringUtil.LTrimStr( (decimal)(A40FlightCapacity), 4, 0));
         O40FlightCapacity = A40FlightCapacity;
         n40FlightCapacity = false;
         AssignAttri("", false, "A40FlightCapacity", StringUtil.LTrimStr( (decimal)(A40FlightCapacity), 4, 0));
         Z33FlightPrice = 0;
         Z34FlightDiscountPercentage = 0;
         Z36AirlineId = 0;
         Z21FlightDepartureAirportId = 0;
         Z23FlightArrivalAirportId = 0;
      }

      protected void InitAll067( )
      {
         A20FlightId = 0;
         AssignAttri("", false, "A20FlightId", StringUtil.LTrimStr( (decimal)(A20FlightId), 4, 0));
         InitializeNonKey067( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey069( )
      {
         A43FlightSeatLocation = "";
         Z43FlightSeatLocation = "";
      }

      protected void InitAll069( )
      {
         A41FlightSeatId = 0;
         A42FlightSeatChar = "";
         InitializeNonKey069( ) ;
      }

      protected void StandaloneModalInsert069( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202622210164634", true, true);
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
         context.AddJavascriptSource("flight.js", "?202622210164634", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties9( )
      {
         cmbFlightSeatChar.Enabled = defcmbFlightSeatChar_Enabled;
         AssignProp("", false, cmbFlightSeatChar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbFlightSeatChar.Enabled), 5, 0), !bGXsfl_138_Refreshing);
         edtFlightSeatId_Enabled = defedtFlightSeatId_Enabled;
         AssignProp("", false, edtFlightSeatId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFlightSeatId_Enabled), 5, 0), !bGXsfl_138_Refreshing);
      }

      protected void StartGridControl138( )
      {
         Gridflight_seatContainer.AddObjectProperty("GridName", "Gridflight_seat");
         Gridflight_seatContainer.AddObjectProperty("Header", subGridflight_seat_Header);
         Gridflight_seatContainer.AddObjectProperty("Class", "Grid");
         Gridflight_seatContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridflight_seatContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridflight_seatContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridflight_seat_Backcolorstyle), 1, 0, ".", "")));
         Gridflight_seatContainer.AddObjectProperty("CmpContext", "");
         Gridflight_seatContainer.AddObjectProperty("InMasterPage", "false");
         Gridflight_seatColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridflight_seatColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A41FlightSeatId), 4, 0, ".", ""))));
         Gridflight_seatColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtFlightSeatId_Enabled), 5, 0, ".", "")));
         Gridflight_seatContainer.AddColumnProperties(Gridflight_seatColumn);
         Gridflight_seatColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridflight_seatColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A42FlightSeatChar)));
         Gridflight_seatColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbFlightSeatChar.Enabled), 5, 0, ".", "")));
         Gridflight_seatContainer.AddColumnProperties(Gridflight_seatColumn);
         Gridflight_seatColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridflight_seatColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A43FlightSeatLocation)));
         Gridflight_seatColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbFlightSeatLocation.Enabled), 5, 0, ".", "")));
         Gridflight_seatContainer.AddColumnProperties(Gridflight_seatColumn);
         Gridflight_seatContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridflight_seat_Selectedindex), 4, 0, ".", "")));
         Gridflight_seatContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridflight_seat_Allowselection), 1, 0, ".", "")));
         Gridflight_seatContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridflight_seat_Selectioncolor), 9, 0, ".", "")));
         Gridflight_seatContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridflight_seat_Allowhovering), 1, 0, ".", "")));
         Gridflight_seatContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridflight_seat_Hoveringcolor), 9, 0, ".", "")));
         Gridflight_seatContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridflight_seat_Allowcollapsing), 1, 0, ".", "")));
         Gridflight_seatContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridflight_seat_Collapsed), 1, 0, ".", "")));
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
         edtFlightId_Internalname = "FLIGHTID";
         edtFlightDepartureAirportId_Internalname = "FLIGHTDEPARTUREAIRPORTID";
         edtFlightDepartureAirportName_Internalname = "FLIGHTDEPARTUREAIRPORTNAME";
         edtFlightDepartureCountryId_Internalname = "FLIGHTDEPARTURECOUNTRYID";
         edtFlightDepartureCountryName_Internalname = "FLIGHTDEPARTURECOUNTRYNAME";
         edtFlightDepartureCityId_Internalname = "FLIGHTDEPARTURECITYID";
         edtFlightDepartureCityName_Internalname = "FLIGHTDEPARTURECITYNAME";
         edtFlightArrivalAirportId_Internalname = "FLIGHTARRIVALAIRPORTID";
         edtFlightArrivalAirportName_Internalname = "FLIGHTARRIVALAIRPORTNAME";
         edtFlightArrivalCountryId_Internalname = "FLIGHTARRIVALCOUNTRYID";
         edtFlightArrivalCountryName_Internalname = "FLIGHTARRIVALCOUNTRYNAME";
         edtFlightArrivalCityId_Internalname = "FLIGHTARRIVALCITYID";
         edtFlightArrivalCityName_Internalname = "FLIGHTARRIVALCITYNAME";
         edtFlightPrice_Internalname = "FLIGHTPRICE";
         edtFlightDiscountPercentage_Internalname = "FLIGHTDISCOUNTPERCENTAGE";
         edtAirlineId_Internalname = "AIRLINEID";
         edtAirlineName_Internalname = "AIRLINENAME";
         edtAirlineDiscountPercentage_Internalname = "AIRLINEDISCOUNTPERCENTAGE";
         edtFlightFinalPrice_Internalname = "FLIGHTFINALPRICE";
         edtFlightCapacity_Internalname = "FLIGHTCAPACITY";
         lblTitleseat_Internalname = "TITLESEAT";
         edtFlightSeatId_Internalname = "FLIGHTSEATID";
         cmbFlightSeatChar_Internalname = "FLIGHTSEATCHAR";
         cmbFlightSeatLocation_Internalname = "FLIGHTSEATLOCATION";
         divSeattable_Internalname = "SEATTABLE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_21_Internalname = "PROMPT_21";
         imgprompt_23_Internalname = "PROMPT_23";
         imgprompt_36_Internalname = "PROMPT_36";
         subGridflight_seat_Internalname = "GRIDFLIGHT_SEAT";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("TravelAgency", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridflight_seat_Allowcollapsing = 0;
         subGridflight_seat_Allowselection = 0;
         subGridflight_seat_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Flight";
         cmbFlightSeatLocation_Jsonclick = "";
         cmbFlightSeatChar_Jsonclick = "";
         edtFlightSeatId_Jsonclick = "";
         subGridflight_seat_Class = "Grid";
         subGridflight_seat_Backcolorstyle = 0;
         cmbFlightSeatLocation.Enabled = 1;
         cmbFlightSeatChar.Enabled = 1;
         edtFlightSeatId_Enabled = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtFlightCapacity_Jsonclick = "";
         edtFlightCapacity_Enabled = 0;
         edtFlightFinalPrice_Jsonclick = "";
         edtFlightFinalPrice_Enabled = 0;
         edtAirlineDiscountPercentage_Jsonclick = "";
         edtAirlineDiscountPercentage_Enabled = 0;
         edtAirlineName_Jsonclick = "";
         edtAirlineName_Enabled = 0;
         imgprompt_36_Visible = 1;
         imgprompt_36_Link = "";
         edtAirlineId_Jsonclick = "";
         edtAirlineId_Enabled = 1;
         edtFlightDiscountPercentage_Jsonclick = "";
         edtFlightDiscountPercentage_Enabled = 1;
         edtFlightPrice_Jsonclick = "";
         edtFlightPrice_Enabled = 1;
         edtFlightArrivalCityName_Jsonclick = "";
         edtFlightArrivalCityName_Enabled = 0;
         edtFlightArrivalCityId_Jsonclick = "";
         edtFlightArrivalCityId_Enabled = 0;
         edtFlightArrivalCountryName_Jsonclick = "";
         edtFlightArrivalCountryName_Enabled = 0;
         edtFlightArrivalCountryId_Jsonclick = "";
         edtFlightArrivalCountryId_Enabled = 0;
         edtFlightArrivalAirportName_Jsonclick = "";
         edtFlightArrivalAirportName_Enabled = 0;
         imgprompt_23_Visible = 1;
         imgprompt_23_Link = "";
         edtFlightArrivalAirportId_Jsonclick = "";
         edtFlightArrivalAirportId_Enabled = 1;
         edtFlightDepartureCityName_Jsonclick = "";
         edtFlightDepartureCityName_Enabled = 0;
         edtFlightDepartureCityId_Jsonclick = "";
         edtFlightDepartureCityId_Enabled = 0;
         edtFlightDepartureCountryName_Jsonclick = "";
         edtFlightDepartureCountryName_Enabled = 0;
         edtFlightDepartureCountryId_Jsonclick = "";
         edtFlightDepartureCountryId_Enabled = 0;
         edtFlightDepartureAirportName_Jsonclick = "";
         edtFlightDepartureAirportName_Enabled = 0;
         imgprompt_21_Visible = 1;
         imgprompt_21_Link = "";
         edtFlightDepartureAirportId_Jsonclick = "";
         edtFlightDepartureAirportId_Enabled = 1;
         edtFlightId_Jsonclick = "";
         edtFlightId_Enabled = 1;
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

      protected void gxnrGridflight_seat_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_1389( ) ;
         while ( nGXsfl_138_idx <= nRC_GXsfl_138 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal069( ) ;
            standaloneModal069( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow069( ) ;
            nGXsfl_138_idx = (int)(nGXsfl_138_idx+1);
            sGXsfl_138_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_138_idx), 4, 0), 4, "0");
            SubsflControlProps_1389( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridflight_seatContainer)) ;
         /* End function gxnrGridflight_seat_newrow */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "FLIGHTSEATCHAR_" + sGXsfl_138_idx;
         cmbFlightSeatChar.Name = GXCCtl;
         cmbFlightSeatChar.WebTags = "";
         cmbFlightSeatChar.addItem("A", "A", 0);
         cmbFlightSeatChar.addItem("B", "B", 0);
         cmbFlightSeatChar.addItem("C", "C", 0);
         cmbFlightSeatChar.addItem("D", "D", 0);
         cmbFlightSeatChar.addItem("E", "E", 0);
         cmbFlightSeatChar.addItem("F", "F", 0);
         if ( cmbFlightSeatChar.ItemCount > 0 )
         {
            A42FlightSeatChar = cmbFlightSeatChar.getValidValue(A42FlightSeatChar);
         }
         GXCCtl = "FLIGHTSEATLOCATION_" + sGXsfl_138_idx;
         cmbFlightSeatLocation.Name = GXCCtl;
         cmbFlightSeatLocation.WebTags = "";
         cmbFlightSeatLocation.addItem("W", "Window", 0);
         cmbFlightSeatLocation.addItem("M", "Middle", 0);
         cmbFlightSeatLocation.addItem("A", "Aisle", 0);
         if ( cmbFlightSeatLocation.ItemCount > 0 )
         {
            A43FlightSeatLocation = cmbFlightSeatLocation.getValidValue(A43FlightSeatLocation);
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtFlightDepartureAirportId_Internalname;
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

      public void Valid_Flightid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         /* Using cursor T000633 */
         pr_default.execute(27, new Object[] {A20FlightId});
         if ( (pr_default.getStatus(27) != 101) )
         {
            A40FlightCapacity = T000633_A40FlightCapacity[0];
            n40FlightCapacity = T000633_n40FlightCapacity[0];
         }
         else
         {
            A40FlightCapacity = 0;
            n40FlightCapacity = false;
         }
         pr_default.close(27);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A21FlightDepartureAirportId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A21FlightDepartureAirportId), 4, 0, ".", "")));
         AssignAttri("", false, "A23FlightArrivalAirportId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A23FlightArrivalAirportId), 4, 0, ".", "")));
         AssignAttri("", false, "A33FlightPrice", StringUtil.LTrim( StringUtil.NToC( A33FlightPrice, 9, 2, ".", "")));
         AssignAttri("", false, "A34FlightDiscountPercentage", StringUtil.LTrim( StringUtil.NToC( (decimal)(A34FlightDiscountPercentage), 3, 0, ".", "")));
         AssignAttri("", false, "A36AirlineId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A36AirlineId), 4, 0, ".", "")));
         AssignAttri("", false, "A40FlightCapacity", StringUtil.LTrim( StringUtil.NToC( (decimal)(A40FlightCapacity), 4, 0, ".", "")));
         AssignAttri("", false, "A22FlightDepartureAirportName", StringUtil.RTrim( A22FlightDepartureAirportName));
         AssignAttri("", false, "A25FlightDepartureCountryId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A25FlightDepartureCountryId), 4, 0, ".", "")));
         AssignAttri("", false, "A27FlightDepartureCityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A27FlightDepartureCityId), 4, 0, ".", "")));
         AssignAttri("", false, "A26FlightDepartureCountryName", StringUtil.RTrim( A26FlightDepartureCountryName));
         AssignAttri("", false, "A28FlightDepartureCityName", StringUtil.RTrim( A28FlightDepartureCityName));
         AssignAttri("", false, "A24FlightArrivalAirportName", StringUtil.RTrim( A24FlightArrivalAirportName));
         AssignAttri("", false, "A29FlightArrivalCountryId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A29FlightArrivalCountryId), 4, 0, ".", "")));
         AssignAttri("", false, "A31FlightArrivalCityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A31FlightArrivalCityId), 4, 0, ".", "")));
         AssignAttri("", false, "A30FlightArrivalCountryName", StringUtil.RTrim( A30FlightArrivalCountryName));
         AssignAttri("", false, "A32FlightArrivalCityName", StringUtil.RTrim( A32FlightArrivalCityName));
         AssignAttri("", false, "A37AirlineName", StringUtil.RTrim( A37AirlineName));
         AssignAttri("", false, "A38AirlineDiscountPercentage", StringUtil.LTrim( StringUtil.NToC( (decimal)(A38AirlineDiscountPercentage), 3, 0, ".", "")));
         AssignAttri("", false, "A35FlightFinalPrice", StringUtil.LTrim( StringUtil.NToC( A35FlightFinalPrice, 9, 2, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z20FlightId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z20FlightId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z21FlightDepartureAirportId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z21FlightDepartureAirportId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z23FlightArrivalAirportId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z23FlightArrivalAirportId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z33FlightPrice", StringUtil.LTrim( StringUtil.NToC( Z33FlightPrice, 9, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z34FlightDiscountPercentage", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z34FlightDiscountPercentage), 3, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z36AirlineId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z36AirlineId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z40FlightCapacity", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z40FlightCapacity), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z22FlightDepartureAirportName", StringUtil.RTrim( Z22FlightDepartureAirportName));
         GxWebStd.gx_hidden_field( context, "Z25FlightDepartureCountryId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z25FlightDepartureCountryId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z27FlightDepartureCityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z27FlightDepartureCityId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z26FlightDepartureCountryName", StringUtil.RTrim( Z26FlightDepartureCountryName));
         GxWebStd.gx_hidden_field( context, "Z28FlightDepartureCityName", StringUtil.RTrim( Z28FlightDepartureCityName));
         GxWebStd.gx_hidden_field( context, "Z24FlightArrivalAirportName", StringUtil.RTrim( Z24FlightArrivalAirportName));
         GxWebStd.gx_hidden_field( context, "Z29FlightArrivalCountryId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z29FlightArrivalCountryId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z31FlightArrivalCityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z31FlightArrivalCityId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z30FlightArrivalCountryName", StringUtil.RTrim( Z30FlightArrivalCountryName));
         GxWebStd.gx_hidden_field( context, "Z32FlightArrivalCityName", StringUtil.RTrim( Z32FlightArrivalCityName));
         GxWebStd.gx_hidden_field( context, "Z37AirlineName", StringUtil.RTrim( Z37AirlineName));
         GxWebStd.gx_hidden_field( context, "Z38AirlineDiscountPercentage", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z38AirlineDiscountPercentage), 3, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z35FlightFinalPrice", StringUtil.LTrim( StringUtil.NToC( Z35FlightFinalPrice, 9, 2, ".", "")));
         AssignAttri("", false, "O40FlightCapacity", StringUtil.LTrim( StringUtil.NToC( (decimal)(O40FlightCapacity), 4, 0, ".", "")));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Flightdepartureairportid( )
      {
         /* Using cursor T000634 */
         pr_default.execute(28, new Object[] {A21FlightDepartureAirportId});
         if ( (pr_default.getStatus(28) == 101) )
         {
            GX_msglist.addItem("No matching 'Flight Departure Airport'.", "ForeignKeyNotFound", 1, "FLIGHTDEPARTUREAIRPORTID");
            AnyError = 1;
            GX_FocusControl = edtFlightDepartureAirportId_Internalname;
         }
         A22FlightDepartureAirportName = T000634_A22FlightDepartureAirportName[0];
         A25FlightDepartureCountryId = T000634_A25FlightDepartureCountryId[0];
         A27FlightDepartureCityId = T000634_A27FlightDepartureCityId[0];
         pr_default.close(28);
         /* Using cursor T000635 */
         pr_default.execute(29, new Object[] {A25FlightDepartureCountryId});
         if ( (pr_default.getStatus(29) == 101) )
         {
            GX_msglist.addItem("No matching 'Flight Departure Airport'.", "ForeignKeyNotFound", 1, "FLIGHTDEPARTURECOUNTRYID");
            AnyError = 1;
         }
         A26FlightDepartureCountryName = T000635_A26FlightDepartureCountryName[0];
         pr_default.close(29);
         /* Using cursor T000636 */
         pr_default.execute(30, new Object[] {A25FlightDepartureCountryId, A27FlightDepartureCityId});
         if ( (pr_default.getStatus(30) == 101) )
         {
            GX_msglist.addItem("No matching 'Flight Departure Airport'.", "ForeignKeyNotFound", 1, "FLIGHTDEPARTURECITYID");
            AnyError = 1;
         }
         A28FlightDepartureCityName = T000636_A28FlightDepartureCityName[0];
         pr_default.close(30);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A22FlightDepartureAirportName", StringUtil.RTrim( A22FlightDepartureAirportName));
         AssignAttri("", false, "A25FlightDepartureCountryId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A25FlightDepartureCountryId), 4, 0, ".", "")));
         AssignAttri("", false, "A27FlightDepartureCityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A27FlightDepartureCityId), 4, 0, ".", "")));
         AssignAttri("", false, "A26FlightDepartureCountryName", StringUtil.RTrim( A26FlightDepartureCountryName));
         AssignAttri("", false, "A28FlightDepartureCityName", StringUtil.RTrim( A28FlightDepartureCityName));
      }

      public void Valid_Flightarrivalairportid( )
      {
         /* Using cursor T000637 */
         pr_default.execute(31, new Object[] {A23FlightArrivalAirportId});
         if ( (pr_default.getStatus(31) == 101) )
         {
            GX_msglist.addItem("No matching 'Flight Arrival Airport'.", "ForeignKeyNotFound", 1, "FLIGHTARRIVALAIRPORTID");
            AnyError = 1;
            GX_FocusControl = edtFlightArrivalAirportId_Internalname;
         }
         A24FlightArrivalAirportName = T000637_A24FlightArrivalAirportName[0];
         A29FlightArrivalCountryId = T000637_A29FlightArrivalCountryId[0];
         A31FlightArrivalCityId = T000637_A31FlightArrivalCityId[0];
         pr_default.close(31);
         /* Using cursor T000638 */
         pr_default.execute(32, new Object[] {A29FlightArrivalCountryId});
         if ( (pr_default.getStatus(32) == 101) )
         {
            GX_msglist.addItem("No matching 'Flight Arrival Airport'.", "ForeignKeyNotFound", 1, "FLIGHTARRIVALCOUNTRYID");
            AnyError = 1;
         }
         A30FlightArrivalCountryName = T000638_A30FlightArrivalCountryName[0];
         pr_default.close(32);
         /* Using cursor T000639 */
         pr_default.execute(33, new Object[] {A29FlightArrivalCountryId, A31FlightArrivalCityId});
         if ( (pr_default.getStatus(33) == 101) )
         {
            GX_msglist.addItem("No matching 'Flight Arrival Airport'.", "ForeignKeyNotFound", 1, "FLIGHTARRIVALCITYID");
            AnyError = 1;
         }
         A32FlightArrivalCityName = T000639_A32FlightArrivalCityName[0];
         pr_default.close(33);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A24FlightArrivalAirportName", StringUtil.RTrim( A24FlightArrivalAirportName));
         AssignAttri("", false, "A29FlightArrivalCountryId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A29FlightArrivalCountryId), 4, 0, ".", "")));
         AssignAttri("", false, "A31FlightArrivalCityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A31FlightArrivalCityId), 4, 0, ".", "")));
         AssignAttri("", false, "A30FlightArrivalCountryName", StringUtil.RTrim( A30FlightArrivalCountryName));
         AssignAttri("", false, "A32FlightArrivalCityName", StringUtil.RTrim( A32FlightArrivalCityName));
      }

      public void Valid_Airlineid( )
      {
         n36AirlineId = false;
         /* Using cursor T000640 */
         pr_default.execute(34, new Object[] {n36AirlineId, A36AirlineId});
         if ( (pr_default.getStatus(34) == 101) )
         {
            if ( ! ( (0==A36AirlineId) ) )
            {
               GX_msglist.addItem("No matching 'Airline'.", "ForeignKeyNotFound", 1, "AIRLINEID");
               AnyError = 1;
               GX_FocusControl = edtAirlineId_Internalname;
            }
         }
         A37AirlineName = T000640_A37AirlineName[0];
         A38AirlineDiscountPercentage = T000640_A38AirlineDiscountPercentage[0];
         pr_default.close(34);
         if ( A38AirlineDiscountPercentage > A34FlightDiscountPercentage )
         {
            A35FlightFinalPrice = (decimal)(A33FlightPrice*(1-A38AirlineDiscountPercentage/ (decimal)(100)));
         }
         else
         {
            A35FlightFinalPrice = (decimal)(A33FlightPrice*(1-A34FlightDiscountPercentage/ (decimal)(100)));
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A37AirlineName", StringUtil.RTrim( A37AirlineName));
         AssignAttri("", false, "A38AirlineDiscountPercentage", StringUtil.LTrim( StringUtil.NToC( (decimal)(A38AirlineDiscountPercentage), 3, 0, ".", "")));
         AssignAttri("", false, "A35FlightFinalPrice", StringUtil.LTrim( StringUtil.NToC( A35FlightFinalPrice, 9, 2, ".", "")));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[]}""");
         setEventMetadata("VALID_FLIGHTID","""{"handler":"Valid_Flightid","iparms":[{"av":"A20FlightId","fld":"FLIGHTID","pic":"ZZZ9"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"}]""");
         setEventMetadata("VALID_FLIGHTID",""","oparms":[{"av":"A21FlightDepartureAirportId","fld":"FLIGHTDEPARTUREAIRPORTID","pic":"ZZZ9"},{"av":"A23FlightArrivalAirportId","fld":"FLIGHTARRIVALAIRPORTID","pic":"ZZZ9"},{"av":"A33FlightPrice","fld":"FLIGHTPRICE","pic":"ZZZZZ9.99"},{"av":"A34FlightDiscountPercentage","fld":"FLIGHTDISCOUNTPERCENTAGE","pic":"ZZ9"},{"av":"A36AirlineId","fld":"AIRLINEID","pic":"ZZZ9"},{"av":"A40FlightCapacity","fld":"FLIGHTCAPACITY","pic":"ZZZ9"},{"av":"A22FlightDepartureAirportName","fld":"FLIGHTDEPARTUREAIRPORTNAME"},{"av":"A25FlightDepartureCountryId","fld":"FLIGHTDEPARTURECOUNTRYID","pic":"ZZZ9"},{"av":"A27FlightDepartureCityId","fld":"FLIGHTDEPARTURECITYID","pic":"ZZZ9"},{"av":"A26FlightDepartureCountryName","fld":"FLIGHTDEPARTURECOUNTRYNAME"},{"av":"A28FlightDepartureCityName","fld":"FLIGHTDEPARTURECITYNAME"},{"av":"A24FlightArrivalAirportName","fld":"FLIGHTARRIVALAIRPORTNAME"},{"av":"A29FlightArrivalCountryId","fld":"FLIGHTARRIVALCOUNTRYID","pic":"ZZZ9"},{"av":"A31FlightArrivalCityId","fld":"FLIGHTARRIVALCITYID","pic":"ZZZ9"},{"av":"A30FlightArrivalCountryName","fld":"FLIGHTARRIVALCOUNTRYNAME"},{"av":"A32FlightArrivalCityName","fld":"FLIGHTARRIVALCITYNAME"},{"av":"A37AirlineName","fld":"AIRLINENAME"},{"av":"A38AirlineDiscountPercentage","fld":"AIRLINEDISCOUNTPERCENTAGE","pic":"ZZ9"},{"av":"A35FlightFinalPrice","fld":"FLIGHTFINALPRICE","pic":"ZZZZZ9.99"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"Z20FlightId"},{"av":"Z21FlightDepartureAirportId"},{"av":"Z23FlightArrivalAirportId"},{"av":"Z33FlightPrice"},{"av":"Z34FlightDiscountPercentage"},{"av":"Z36AirlineId"},{"av":"Z40FlightCapacity"},{"av":"Z22FlightDepartureAirportName"},{"av":"Z25FlightDepartureCountryId"},{"av":"Z27FlightDepartureCityId"},{"av":"Z26FlightDepartureCountryName"},{"av":"Z28FlightDepartureCityName"},{"av":"Z24FlightArrivalAirportName"},{"av":"Z29FlightArrivalCountryId"},{"av":"Z31FlightArrivalCityId"},{"av":"Z30FlightArrivalCountryName"},{"av":"Z32FlightArrivalCityName"},{"av":"Z37AirlineName"},{"av":"Z38AirlineDiscountPercentage"},{"av":"Z35FlightFinalPrice"},{"av":"O40FlightCapacity"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"}]}""");
         setEventMetadata("VALID_FLIGHTDEPARTUREAIRPORTID","""{"handler":"Valid_Flightdepartureairportid","iparms":[{"av":"A21FlightDepartureAirportId","fld":"FLIGHTDEPARTUREAIRPORTID","pic":"ZZZ9"},{"av":"A25FlightDepartureCountryId","fld":"FLIGHTDEPARTURECOUNTRYID","pic":"ZZZ9"},{"av":"A27FlightDepartureCityId","fld":"FLIGHTDEPARTURECITYID","pic":"ZZZ9"},{"av":"A22FlightDepartureAirportName","fld":"FLIGHTDEPARTUREAIRPORTNAME"},{"av":"A26FlightDepartureCountryName","fld":"FLIGHTDEPARTURECOUNTRYNAME"},{"av":"A28FlightDepartureCityName","fld":"FLIGHTDEPARTURECITYNAME"}]""");
         setEventMetadata("VALID_FLIGHTDEPARTUREAIRPORTID",""","oparms":[{"av":"A22FlightDepartureAirportName","fld":"FLIGHTDEPARTUREAIRPORTNAME"},{"av":"A25FlightDepartureCountryId","fld":"FLIGHTDEPARTURECOUNTRYID","pic":"ZZZ9"},{"av":"A27FlightDepartureCityId","fld":"FLIGHTDEPARTURECITYID","pic":"ZZZ9"},{"av":"A26FlightDepartureCountryName","fld":"FLIGHTDEPARTURECOUNTRYNAME"},{"av":"A28FlightDepartureCityName","fld":"FLIGHTDEPARTURECITYNAME"}]}""");
         setEventMetadata("VALID_FLIGHTDEPARTURECOUNTRYID","""{"handler":"Valid_Flightdeparturecountryid","iparms":[]}""");
         setEventMetadata("VALID_FLIGHTDEPARTURECITYID","""{"handler":"Valid_Flightdeparturecityid","iparms":[]}""");
         setEventMetadata("VALID_FLIGHTARRIVALAIRPORTID","""{"handler":"Valid_Flightarrivalairportid","iparms":[{"av":"A23FlightArrivalAirportId","fld":"FLIGHTARRIVALAIRPORTID","pic":"ZZZ9"},{"av":"A29FlightArrivalCountryId","fld":"FLIGHTARRIVALCOUNTRYID","pic":"ZZZ9"},{"av":"A31FlightArrivalCityId","fld":"FLIGHTARRIVALCITYID","pic":"ZZZ9"},{"av":"A24FlightArrivalAirportName","fld":"FLIGHTARRIVALAIRPORTNAME"},{"av":"A30FlightArrivalCountryName","fld":"FLIGHTARRIVALCOUNTRYNAME"},{"av":"A32FlightArrivalCityName","fld":"FLIGHTARRIVALCITYNAME"}]""");
         setEventMetadata("VALID_FLIGHTARRIVALAIRPORTID",""","oparms":[{"av":"A24FlightArrivalAirportName","fld":"FLIGHTARRIVALAIRPORTNAME"},{"av":"A29FlightArrivalCountryId","fld":"FLIGHTARRIVALCOUNTRYID","pic":"ZZZ9"},{"av":"A31FlightArrivalCityId","fld":"FLIGHTARRIVALCITYID","pic":"ZZZ9"},{"av":"A30FlightArrivalCountryName","fld":"FLIGHTARRIVALCOUNTRYNAME"},{"av":"A32FlightArrivalCityName","fld":"FLIGHTARRIVALCITYNAME"}]}""");
         setEventMetadata("VALID_FLIGHTARRIVALCOUNTRYID","""{"handler":"Valid_Flightarrivalcountryid","iparms":[]}""");
         setEventMetadata("VALID_FLIGHTARRIVALCITYID","""{"handler":"Valid_Flightarrivalcityid","iparms":[]}""");
         setEventMetadata("VALID_FLIGHTPRICE","""{"handler":"Valid_Flightprice","iparms":[]}""");
         setEventMetadata("VALID_FLIGHTDISCOUNTPERCENTAGE","""{"handler":"Valid_Flightdiscountpercentage","iparms":[]}""");
         setEventMetadata("VALID_AIRLINEID","""{"handler":"Valid_Airlineid","iparms":[{"av":"A36AirlineId","fld":"AIRLINEID","pic":"ZZZ9"},{"av":"A33FlightPrice","fld":"FLIGHTPRICE","pic":"ZZZZZ9.99"},{"av":"A38AirlineDiscountPercentage","fld":"AIRLINEDISCOUNTPERCENTAGE","pic":"ZZ9"},{"av":"A34FlightDiscountPercentage","fld":"FLIGHTDISCOUNTPERCENTAGE","pic":"ZZ9"},{"av":"A37AirlineName","fld":"AIRLINENAME"},{"av":"A35FlightFinalPrice","fld":"FLIGHTFINALPRICE","pic":"ZZZZZ9.99"}]""");
         setEventMetadata("VALID_AIRLINEID",""","oparms":[{"av":"A37AirlineName","fld":"AIRLINENAME"},{"av":"A38AirlineDiscountPercentage","fld":"AIRLINEDISCOUNTPERCENTAGE","pic":"ZZ9"},{"av":"A35FlightFinalPrice","fld":"FLIGHTFINALPRICE","pic":"ZZZZZ9.99"}]}""");
         setEventMetadata("VALID_AIRLINEDISCOUNTPERCENTAGE","""{"handler":"Valid_Airlinediscountpercentage","iparms":[]}""");
         setEventMetadata("VALID_FLIGHTCAPACITY","""{"handler":"Valid_Flightcapacity","iparms":[]}""");
         setEventMetadata("VALID_FLIGHTSEATID","""{"handler":"Valid_Flightseatid","iparms":[]}""");
         setEventMetadata("VALID_FLIGHTSEATCHAR","""{"handler":"Valid_Flightseatchar","iparms":[]}""");
         setEventMetadata("VALID_FLIGHTSEATLOCATION","""{"handler":"Valid_Flightseatlocation","iparms":[]}""");
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
         pr_default.close(3);
         pr_default.close(34);
         pr_default.close(28);
         pr_default.close(31);
         pr_default.close(29);
         pr_default.close(30);
         pr_default.close(32);
         pr_default.close(33);
         pr_default.close(27);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z42FlightSeatChar = "";
         Z43FlightSeatLocation = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         Gx_mode = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         imgprompt_21_gximage = "";
         sImgUrl = "";
         A22FlightDepartureAirportName = "";
         A26FlightDepartureCountryName = "";
         A28FlightDepartureCityName = "";
         imgprompt_23_gximage = "";
         A24FlightArrivalAirportName = "";
         A30FlightArrivalCountryName = "";
         A32FlightArrivalCityName = "";
         imgprompt_36_gximage = "";
         A37AirlineName = "";
         lblTitleseat_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gridflight_seatContainer = new GXWebGrid( context);
         sMode9 = "";
         sStyleString = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         A42FlightSeatChar = "";
         A43FlightSeatLocation = "";
         Z22FlightDepartureAirportName = "";
         Z26FlightDepartureCountryName = "";
         Z28FlightDepartureCityName = "";
         Z24FlightArrivalAirportName = "";
         Z30FlightArrivalCountryName = "";
         Z32FlightArrivalCityName = "";
         Z37AirlineName = "";
         T000616_A20FlightId = new short[1] ;
         T000616_A22FlightDepartureAirportName = new string[] {""} ;
         T000616_A26FlightDepartureCountryName = new string[] {""} ;
         T000616_A28FlightDepartureCityName = new string[] {""} ;
         T000616_A24FlightArrivalAirportName = new string[] {""} ;
         T000616_A30FlightArrivalCountryName = new string[] {""} ;
         T000616_A32FlightArrivalCityName = new string[] {""} ;
         T000616_A33FlightPrice = new decimal[1] ;
         T000616_A34FlightDiscountPercentage = new short[1] ;
         T000616_A37AirlineName = new string[] {""} ;
         T000616_A38AirlineDiscountPercentage = new short[1] ;
         T000616_A36AirlineId = new short[1] ;
         T000616_n36AirlineId = new bool[] {false} ;
         T000616_A21FlightDepartureAirportId = new short[1] ;
         T000616_A23FlightArrivalAirportId = new short[1] ;
         T000616_A25FlightDepartureCountryId = new short[1] ;
         T000616_A27FlightDepartureCityId = new short[1] ;
         T000616_A29FlightArrivalCountryId = new short[1] ;
         T000616_A31FlightArrivalCityId = new short[1] ;
         T000616_A40FlightCapacity = new short[1] ;
         T000616_n40FlightCapacity = new bool[] {false} ;
         T000614_A40FlightCapacity = new short[1] ;
         T000614_n40FlightCapacity = new bool[] {false} ;
         T00067_A22FlightDepartureAirportName = new string[] {""} ;
         T00067_A25FlightDepartureCountryId = new short[1] ;
         T00067_A27FlightDepartureCityId = new short[1] ;
         T00069_A26FlightDepartureCountryName = new string[] {""} ;
         T000610_A28FlightDepartureCityName = new string[] {""} ;
         T00068_A24FlightArrivalAirportName = new string[] {""} ;
         T00068_A29FlightArrivalCountryId = new short[1] ;
         T00068_A31FlightArrivalCityId = new short[1] ;
         T000611_A30FlightArrivalCountryName = new string[] {""} ;
         T000612_A32FlightArrivalCityName = new string[] {""} ;
         T00066_A37AirlineName = new string[] {""} ;
         T00066_A38AirlineDiscountPercentage = new short[1] ;
         T000618_A40FlightCapacity = new short[1] ;
         T000618_n40FlightCapacity = new bool[] {false} ;
         T000619_A22FlightDepartureAirportName = new string[] {""} ;
         T000619_A25FlightDepartureCountryId = new short[1] ;
         T000619_A27FlightDepartureCityId = new short[1] ;
         T000620_A26FlightDepartureCountryName = new string[] {""} ;
         T000621_A28FlightDepartureCityName = new string[] {""} ;
         T000622_A24FlightArrivalAirportName = new string[] {""} ;
         T000622_A29FlightArrivalCountryId = new short[1] ;
         T000622_A31FlightArrivalCityId = new short[1] ;
         T000623_A30FlightArrivalCountryName = new string[] {""} ;
         T000624_A32FlightArrivalCityName = new string[] {""} ;
         T000625_A37AirlineName = new string[] {""} ;
         T000625_A38AirlineDiscountPercentage = new short[1] ;
         T000626_A20FlightId = new short[1] ;
         T00065_A20FlightId = new short[1] ;
         T00065_A33FlightPrice = new decimal[1] ;
         T00065_A34FlightDiscountPercentage = new short[1] ;
         T00065_A36AirlineId = new short[1] ;
         T00065_n36AirlineId = new bool[] {false} ;
         T00065_A21FlightDepartureAirportId = new short[1] ;
         T00065_A23FlightArrivalAirportId = new short[1] ;
         sMode7 = "";
         T000627_A20FlightId = new short[1] ;
         T000628_A20FlightId = new short[1] ;
         T00064_A20FlightId = new short[1] ;
         T00064_A33FlightPrice = new decimal[1] ;
         T00064_A34FlightDiscountPercentage = new short[1] ;
         T00064_A36AirlineId = new short[1] ;
         T00064_n36AirlineId = new bool[] {false} ;
         T00064_A21FlightDepartureAirportId = new short[1] ;
         T00064_A23FlightArrivalAirportId = new short[1] ;
         T000629_A20FlightId = new short[1] ;
         T000633_A40FlightCapacity = new short[1] ;
         T000633_n40FlightCapacity = new bool[] {false} ;
         T000634_A22FlightDepartureAirportName = new string[] {""} ;
         T000634_A25FlightDepartureCountryId = new short[1] ;
         T000634_A27FlightDepartureCityId = new short[1] ;
         T000635_A26FlightDepartureCountryName = new string[] {""} ;
         T000636_A28FlightDepartureCityName = new string[] {""} ;
         T000637_A24FlightArrivalAirportName = new string[] {""} ;
         T000637_A29FlightArrivalCountryId = new short[1] ;
         T000637_A31FlightArrivalCityId = new short[1] ;
         T000638_A30FlightArrivalCountryName = new string[] {""} ;
         T000639_A32FlightArrivalCityName = new string[] {""} ;
         T000640_A37AirlineName = new string[] {""} ;
         T000640_A38AirlineDiscountPercentage = new short[1] ;
         T000641_A20FlightId = new short[1] ;
         T000642_A20FlightId = new short[1] ;
         T000642_A41FlightSeatId = new short[1] ;
         T000642_A42FlightSeatChar = new string[] {""} ;
         T000642_A43FlightSeatLocation = new string[] {""} ;
         T000643_A20FlightId = new short[1] ;
         T000643_A41FlightSeatId = new short[1] ;
         T000643_A42FlightSeatChar = new string[] {""} ;
         T00063_A20FlightId = new short[1] ;
         T00063_A41FlightSeatId = new short[1] ;
         T00063_A42FlightSeatChar = new string[] {""} ;
         T00063_A43FlightSeatLocation = new string[] {""} ;
         T00062_A20FlightId = new short[1] ;
         T00062_A41FlightSeatId = new short[1] ;
         T00062_A42FlightSeatChar = new string[] {""} ;
         T00062_A43FlightSeatLocation = new string[] {""} ;
         T000647_A20FlightId = new short[1] ;
         T000647_A41FlightSeatId = new short[1] ;
         T000647_A42FlightSeatChar = new string[] {""} ;
         Gridflight_seatRow = new GXWebRow();
         subGridflight_seat_Linesclass = "";
         ROClassString = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         Gridflight_seatColumn = new GXWebColumn();
         ZZ22FlightDepartureAirportName = "";
         ZZ26FlightDepartureCountryName = "";
         ZZ28FlightDepartureCityName = "";
         ZZ24FlightArrivalAirportName = "";
         ZZ30FlightArrivalCountryName = "";
         ZZ32FlightArrivalCityName = "";
         ZZ37AirlineName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.flight__default(),
            new Object[][] {
                new Object[] {
               T00062_A20FlightId, T00062_A41FlightSeatId, T00062_A42FlightSeatChar, T00062_A43FlightSeatLocation
               }
               , new Object[] {
               T00063_A20FlightId, T00063_A41FlightSeatId, T00063_A42FlightSeatChar, T00063_A43FlightSeatLocation
               }
               , new Object[] {
               T00064_A20FlightId, T00064_A33FlightPrice, T00064_A34FlightDiscountPercentage, T00064_A36AirlineId, T00064_n36AirlineId, T00064_A21FlightDepartureAirportId, T00064_A23FlightArrivalAirportId
               }
               , new Object[] {
               T00065_A20FlightId, T00065_A33FlightPrice, T00065_A34FlightDiscountPercentage, T00065_A36AirlineId, T00065_n36AirlineId, T00065_A21FlightDepartureAirportId, T00065_A23FlightArrivalAirportId
               }
               , new Object[] {
               T00066_A37AirlineName, T00066_A38AirlineDiscountPercentage
               }
               , new Object[] {
               T00067_A22FlightDepartureAirportName, T00067_A25FlightDepartureCountryId, T00067_A27FlightDepartureCityId
               }
               , new Object[] {
               T00068_A24FlightArrivalAirportName, T00068_A29FlightArrivalCountryId, T00068_A31FlightArrivalCityId
               }
               , new Object[] {
               T00069_A26FlightDepartureCountryName
               }
               , new Object[] {
               T000610_A28FlightDepartureCityName
               }
               , new Object[] {
               T000611_A30FlightArrivalCountryName
               }
               , new Object[] {
               T000612_A32FlightArrivalCityName
               }
               , new Object[] {
               T000614_A40FlightCapacity, T000614_n40FlightCapacity
               }
               , new Object[] {
               T000616_A20FlightId, T000616_A22FlightDepartureAirportName, T000616_A26FlightDepartureCountryName, T000616_A28FlightDepartureCityName, T000616_A24FlightArrivalAirportName, T000616_A30FlightArrivalCountryName, T000616_A32FlightArrivalCityName, T000616_A33FlightPrice, T000616_A34FlightDiscountPercentage, T000616_A37AirlineName,
               T000616_A38AirlineDiscountPercentage, T000616_A36AirlineId, T000616_n36AirlineId, T000616_A21FlightDepartureAirportId, T000616_A23FlightArrivalAirportId, T000616_A25FlightDepartureCountryId, T000616_A27FlightDepartureCityId, T000616_A29FlightArrivalCountryId, T000616_A31FlightArrivalCityId, T000616_A40FlightCapacity,
               T000616_n40FlightCapacity
               }
               , new Object[] {
               T000618_A40FlightCapacity, T000618_n40FlightCapacity
               }
               , new Object[] {
               T000619_A22FlightDepartureAirportName, T000619_A25FlightDepartureCountryId, T000619_A27FlightDepartureCityId
               }
               , new Object[] {
               T000620_A26FlightDepartureCountryName
               }
               , new Object[] {
               T000621_A28FlightDepartureCityName
               }
               , new Object[] {
               T000622_A24FlightArrivalAirportName, T000622_A29FlightArrivalCountryId, T000622_A31FlightArrivalCityId
               }
               , new Object[] {
               T000623_A30FlightArrivalCountryName
               }
               , new Object[] {
               T000624_A32FlightArrivalCityName
               }
               , new Object[] {
               T000625_A37AirlineName, T000625_A38AirlineDiscountPercentage
               }
               , new Object[] {
               T000626_A20FlightId
               }
               , new Object[] {
               T000627_A20FlightId
               }
               , new Object[] {
               T000628_A20FlightId
               }
               , new Object[] {
               T000629_A20FlightId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000633_A40FlightCapacity, T000633_n40FlightCapacity
               }
               , new Object[] {
               T000634_A22FlightDepartureAirportName, T000634_A25FlightDepartureCountryId, T000634_A27FlightDepartureCityId
               }
               , new Object[] {
               T000635_A26FlightDepartureCountryName
               }
               , new Object[] {
               T000636_A28FlightDepartureCityName
               }
               , new Object[] {
               T000637_A24FlightArrivalAirportName, T000637_A29FlightArrivalCountryId, T000637_A31FlightArrivalCityId
               }
               , new Object[] {
               T000638_A30FlightArrivalCountryName
               }
               , new Object[] {
               T000639_A32FlightArrivalCityName
               }
               , new Object[] {
               T000640_A37AirlineName, T000640_A38AirlineDiscountPercentage
               }
               , new Object[] {
               T000641_A20FlightId
               }
               , new Object[] {
               T000642_A20FlightId, T000642_A41FlightSeatId, T000642_A42FlightSeatChar, T000642_A43FlightSeatLocation
               }
               , new Object[] {
               T000643_A20FlightId, T000643_A41FlightSeatId, T000643_A42FlightSeatChar
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000647_A20FlightId, T000647_A41FlightSeatId, T000647_A42FlightSeatChar
               }
            }
         );
      }

      private short Z20FlightId ;
      private short Z34FlightDiscountPercentage ;
      private short Z36AirlineId ;
      private short Z21FlightDepartureAirportId ;
      private short Z23FlightArrivalAirportId ;
      private short O40FlightCapacity ;
      private short Z41FlightSeatId ;
      private short nRcdDeleted_9 ;
      private short nRcdExists_9 ;
      private short nIsMod_9 ;
      private short GxWebError ;
      private short A20FlightId ;
      private short A21FlightDepartureAirportId ;
      private short A25FlightDepartureCountryId ;
      private short A27FlightDepartureCityId ;
      private short A23FlightArrivalAirportId ;
      private short A29FlightArrivalCountryId ;
      private short A31FlightArrivalCityId ;
      private short A36AirlineId ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A34FlightDiscountPercentage ;
      private short A38AirlineDiscountPercentage ;
      private short A40FlightCapacity ;
      private short nBlankRcdCount9 ;
      private short RcdFound9 ;
      private short B40FlightCapacity ;
      private short nBlankRcdUsr9 ;
      private short s40FlightCapacity ;
      private short A41FlightSeatId ;
      private short Z40FlightCapacity ;
      private short Z25FlightDepartureCountryId ;
      private short Z27FlightDepartureCityId ;
      private short Z29FlightArrivalCountryId ;
      private short Z31FlightArrivalCityId ;
      private short Z38AirlineDiscountPercentage ;
      private short RcdFound7 ;
      private short Gx_BScreen ;
      private short nIsDirty_9 ;
      private short subGridflight_seat_Backcolorstyle ;
      private short subGridflight_seat_Backstyle ;
      private short gxajaxcallmode ;
      private short subGridflight_seat_Allowselection ;
      private short subGridflight_seat_Allowhovering ;
      private short subGridflight_seat_Allowcollapsing ;
      private short subGridflight_seat_Collapsed ;
      private short ZZ20FlightId ;
      private short ZZ21FlightDepartureAirportId ;
      private short ZZ23FlightArrivalAirportId ;
      private short ZZ34FlightDiscountPercentage ;
      private short ZZ36AirlineId ;
      private short ZZ40FlightCapacity ;
      private short ZZ25FlightDepartureCountryId ;
      private short ZZ27FlightDepartureCityId ;
      private short ZZ29FlightArrivalCountryId ;
      private short ZZ31FlightArrivalCityId ;
      private short ZZ38AirlineDiscountPercentage ;
      private short ZO40FlightCapacity ;
      private int nRC_GXsfl_138 ;
      private int nGXsfl_138_idx=1 ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtFlightId_Enabled ;
      private int edtFlightDepartureAirportId_Enabled ;
      private int imgprompt_21_Visible ;
      private int edtFlightDepartureAirportName_Enabled ;
      private int edtFlightDepartureCountryId_Enabled ;
      private int edtFlightDepartureCountryName_Enabled ;
      private int edtFlightDepartureCityId_Enabled ;
      private int edtFlightDepartureCityName_Enabled ;
      private int edtFlightArrivalAirportId_Enabled ;
      private int imgprompt_23_Visible ;
      private int edtFlightArrivalAirportName_Enabled ;
      private int edtFlightArrivalCountryId_Enabled ;
      private int edtFlightArrivalCountryName_Enabled ;
      private int edtFlightArrivalCityId_Enabled ;
      private int edtFlightArrivalCityName_Enabled ;
      private int edtFlightPrice_Enabled ;
      private int edtFlightDiscountPercentage_Enabled ;
      private int edtAirlineId_Enabled ;
      private int imgprompt_36_Visible ;
      private int edtAirlineName_Enabled ;
      private int edtAirlineDiscountPercentage_Enabled ;
      private int edtFlightFinalPrice_Enabled ;
      private int edtFlightCapacity_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int edtFlightSeatId_Enabled ;
      private int fRowAdded ;
      private int subGridflight_seat_Backcolor ;
      private int subGridflight_seat_Allbackcolor ;
      private int defcmbFlightSeatChar_Enabled ;
      private int defedtFlightSeatId_Enabled ;
      private int idxLst ;
      private int subGridflight_seat_Selectedindex ;
      private int subGridflight_seat_Selectioncolor ;
      private int subGridflight_seat_Hoveringcolor ;
      private long GRIDFLIGHT_SEAT_nFirstRecordOnPage ;
      private decimal Z33FlightPrice ;
      private decimal A33FlightPrice ;
      private decimal A35FlightFinalPrice ;
      private decimal Z35FlightFinalPrice ;
      private decimal ZZ33FlightPrice ;
      private decimal ZZ35FlightFinalPrice ;
      private string sPrefix ;
      private string Z42FlightSeatChar ;
      private string Z43FlightSeatLocation ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtFlightId_Internalname ;
      private string sGXsfl_138_idx="0001" ;
      private string Gx_mode ;
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
      private string edtFlightId_Jsonclick ;
      private string edtFlightDepartureAirportId_Internalname ;
      private string edtFlightDepartureAirportId_Jsonclick ;
      private string imgprompt_21_gximage ;
      private string sImgUrl ;
      private string imgprompt_21_Internalname ;
      private string imgprompt_21_Link ;
      private string edtFlightDepartureAirportName_Internalname ;
      private string A22FlightDepartureAirportName ;
      private string edtFlightDepartureAirportName_Jsonclick ;
      private string edtFlightDepartureCountryId_Internalname ;
      private string edtFlightDepartureCountryId_Jsonclick ;
      private string edtFlightDepartureCountryName_Internalname ;
      private string A26FlightDepartureCountryName ;
      private string edtFlightDepartureCountryName_Jsonclick ;
      private string edtFlightDepartureCityId_Internalname ;
      private string edtFlightDepartureCityId_Jsonclick ;
      private string edtFlightDepartureCityName_Internalname ;
      private string A28FlightDepartureCityName ;
      private string edtFlightDepartureCityName_Jsonclick ;
      private string edtFlightArrivalAirportId_Internalname ;
      private string edtFlightArrivalAirportId_Jsonclick ;
      private string imgprompt_23_gximage ;
      private string imgprompt_23_Internalname ;
      private string imgprompt_23_Link ;
      private string edtFlightArrivalAirportName_Internalname ;
      private string A24FlightArrivalAirportName ;
      private string edtFlightArrivalAirportName_Jsonclick ;
      private string edtFlightArrivalCountryId_Internalname ;
      private string edtFlightArrivalCountryId_Jsonclick ;
      private string edtFlightArrivalCountryName_Internalname ;
      private string A30FlightArrivalCountryName ;
      private string edtFlightArrivalCountryName_Jsonclick ;
      private string edtFlightArrivalCityId_Internalname ;
      private string edtFlightArrivalCityId_Jsonclick ;
      private string edtFlightArrivalCityName_Internalname ;
      private string A32FlightArrivalCityName ;
      private string edtFlightArrivalCityName_Jsonclick ;
      private string edtFlightPrice_Internalname ;
      private string edtFlightPrice_Jsonclick ;
      private string edtFlightDiscountPercentage_Internalname ;
      private string edtFlightDiscountPercentage_Jsonclick ;
      private string edtAirlineId_Internalname ;
      private string edtAirlineId_Jsonclick ;
      private string imgprompt_36_gximage ;
      private string imgprompt_36_Internalname ;
      private string imgprompt_36_Link ;
      private string edtAirlineName_Internalname ;
      private string A37AirlineName ;
      private string edtAirlineName_Jsonclick ;
      private string edtAirlineDiscountPercentage_Internalname ;
      private string edtAirlineDiscountPercentage_Jsonclick ;
      private string edtFlightFinalPrice_Internalname ;
      private string edtFlightFinalPrice_Jsonclick ;
      private string edtFlightCapacity_Internalname ;
      private string edtFlightCapacity_Jsonclick ;
      private string divSeattable_Internalname ;
      private string lblTitleseat_Internalname ;
      private string lblTitleseat_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string sMode9 ;
      private string edtFlightSeatId_Internalname ;
      private string cmbFlightSeatChar_Internalname ;
      private string cmbFlightSeatLocation_Internalname ;
      private string sStyleString ;
      private string subGridflight_seat_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string A42FlightSeatChar ;
      private string A43FlightSeatLocation ;
      private string Z22FlightDepartureAirportName ;
      private string Z26FlightDepartureCountryName ;
      private string Z28FlightDepartureCityName ;
      private string Z24FlightArrivalAirportName ;
      private string Z30FlightArrivalCountryName ;
      private string Z32FlightArrivalCityName ;
      private string Z37AirlineName ;
      private string sMode7 ;
      private string sGXsfl_138_fel_idx="0001" ;
      private string subGridflight_seat_Class ;
      private string subGridflight_seat_Linesclass ;
      private string ROClassString ;
      private string edtFlightSeatId_Jsonclick ;
      private string cmbFlightSeatChar_Jsonclick ;
      private string cmbFlightSeatLocation_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridflight_seat_Header ;
      private string ZZ22FlightDepartureAirportName ;
      private string ZZ26FlightDepartureCountryName ;
      private string ZZ28FlightDepartureCityName ;
      private string ZZ24FlightArrivalAirportName ;
      private string ZZ30FlightArrivalCountryName ;
      private string ZZ32FlightArrivalCityName ;
      private string ZZ37AirlineName ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n36AirlineId ;
      private bool wbErr ;
      private bool n40FlightCapacity ;
      private bool bGXsfl_138_Refreshing=false ;
      private GXWebGrid Gridflight_seatContainer ;
      private GXWebRow Gridflight_seatRow ;
      private GXWebColumn Gridflight_seatColumn ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbFlightSeatChar ;
      private GXCombobox cmbFlightSeatLocation ;
      private IDataStoreProvider pr_default ;
      private short[] T000616_A20FlightId ;
      private string[] T000616_A22FlightDepartureAirportName ;
      private string[] T000616_A26FlightDepartureCountryName ;
      private string[] T000616_A28FlightDepartureCityName ;
      private string[] T000616_A24FlightArrivalAirportName ;
      private string[] T000616_A30FlightArrivalCountryName ;
      private string[] T000616_A32FlightArrivalCityName ;
      private decimal[] T000616_A33FlightPrice ;
      private short[] T000616_A34FlightDiscountPercentage ;
      private string[] T000616_A37AirlineName ;
      private short[] T000616_A38AirlineDiscountPercentage ;
      private short[] T000616_A36AirlineId ;
      private bool[] T000616_n36AirlineId ;
      private short[] T000616_A21FlightDepartureAirportId ;
      private short[] T000616_A23FlightArrivalAirportId ;
      private short[] T000616_A25FlightDepartureCountryId ;
      private short[] T000616_A27FlightDepartureCityId ;
      private short[] T000616_A29FlightArrivalCountryId ;
      private short[] T000616_A31FlightArrivalCityId ;
      private short[] T000616_A40FlightCapacity ;
      private bool[] T000616_n40FlightCapacity ;
      private short[] T000614_A40FlightCapacity ;
      private bool[] T000614_n40FlightCapacity ;
      private string[] T00067_A22FlightDepartureAirportName ;
      private short[] T00067_A25FlightDepartureCountryId ;
      private short[] T00067_A27FlightDepartureCityId ;
      private string[] T00069_A26FlightDepartureCountryName ;
      private string[] T000610_A28FlightDepartureCityName ;
      private string[] T00068_A24FlightArrivalAirportName ;
      private short[] T00068_A29FlightArrivalCountryId ;
      private short[] T00068_A31FlightArrivalCityId ;
      private string[] T000611_A30FlightArrivalCountryName ;
      private string[] T000612_A32FlightArrivalCityName ;
      private string[] T00066_A37AirlineName ;
      private short[] T00066_A38AirlineDiscountPercentage ;
      private short[] T000618_A40FlightCapacity ;
      private bool[] T000618_n40FlightCapacity ;
      private string[] T000619_A22FlightDepartureAirportName ;
      private short[] T000619_A25FlightDepartureCountryId ;
      private short[] T000619_A27FlightDepartureCityId ;
      private string[] T000620_A26FlightDepartureCountryName ;
      private string[] T000621_A28FlightDepartureCityName ;
      private string[] T000622_A24FlightArrivalAirportName ;
      private short[] T000622_A29FlightArrivalCountryId ;
      private short[] T000622_A31FlightArrivalCityId ;
      private string[] T000623_A30FlightArrivalCountryName ;
      private string[] T000624_A32FlightArrivalCityName ;
      private string[] T000625_A37AirlineName ;
      private short[] T000625_A38AirlineDiscountPercentage ;
      private short[] T000626_A20FlightId ;
      private short[] T00065_A20FlightId ;
      private decimal[] T00065_A33FlightPrice ;
      private short[] T00065_A34FlightDiscountPercentage ;
      private short[] T00065_A36AirlineId ;
      private bool[] T00065_n36AirlineId ;
      private short[] T00065_A21FlightDepartureAirportId ;
      private short[] T00065_A23FlightArrivalAirportId ;
      private short[] T000627_A20FlightId ;
      private short[] T000628_A20FlightId ;
      private short[] T00064_A20FlightId ;
      private decimal[] T00064_A33FlightPrice ;
      private short[] T00064_A34FlightDiscountPercentage ;
      private short[] T00064_A36AirlineId ;
      private bool[] T00064_n36AirlineId ;
      private short[] T00064_A21FlightDepartureAirportId ;
      private short[] T00064_A23FlightArrivalAirportId ;
      private short[] T000629_A20FlightId ;
      private short[] T000633_A40FlightCapacity ;
      private bool[] T000633_n40FlightCapacity ;
      private string[] T000634_A22FlightDepartureAirportName ;
      private short[] T000634_A25FlightDepartureCountryId ;
      private short[] T000634_A27FlightDepartureCityId ;
      private string[] T000635_A26FlightDepartureCountryName ;
      private string[] T000636_A28FlightDepartureCityName ;
      private string[] T000637_A24FlightArrivalAirportName ;
      private short[] T000637_A29FlightArrivalCountryId ;
      private short[] T000637_A31FlightArrivalCityId ;
      private string[] T000638_A30FlightArrivalCountryName ;
      private string[] T000639_A32FlightArrivalCityName ;
      private string[] T000640_A37AirlineName ;
      private short[] T000640_A38AirlineDiscountPercentage ;
      private short[] T000641_A20FlightId ;
      private short[] T000642_A20FlightId ;
      private short[] T000642_A41FlightSeatId ;
      private string[] T000642_A42FlightSeatChar ;
      private string[] T000642_A43FlightSeatLocation ;
      private short[] T000643_A20FlightId ;
      private short[] T000643_A41FlightSeatId ;
      private string[] T000643_A42FlightSeatChar ;
      private short[] T00063_A20FlightId ;
      private short[] T00063_A41FlightSeatId ;
      private string[] T00063_A42FlightSeatChar ;
      private string[] T00063_A43FlightSeatLocation ;
      private short[] T00062_A20FlightId ;
      private short[] T00062_A41FlightSeatId ;
      private string[] T00062_A42FlightSeatChar ;
      private string[] T00062_A43FlightSeatLocation ;
      private short[] T000647_A20FlightId ;
      private short[] T000647_A41FlightSeatId ;
      private string[] T000647_A42FlightSeatChar ;
   }

   public class flight__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new ForEachCursor(def[21])
         ,new ForEachCursor(def[22])
         ,new ForEachCursor(def[23])
         ,new ForEachCursor(def[24])
         ,new UpdateCursor(def[25])
         ,new UpdateCursor(def[26])
         ,new ForEachCursor(def[27])
         ,new ForEachCursor(def[28])
         ,new ForEachCursor(def[29])
         ,new ForEachCursor(def[30])
         ,new ForEachCursor(def[31])
         ,new ForEachCursor(def[32])
         ,new ForEachCursor(def[33])
         ,new ForEachCursor(def[34])
         ,new ForEachCursor(def[35])
         ,new ForEachCursor(def[36])
         ,new ForEachCursor(def[37])
         ,new UpdateCursor(def[38])
         ,new UpdateCursor(def[39])
         ,new UpdateCursor(def[40])
         ,new ForEachCursor(def[41])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00062;
          prmT00062 = new Object[] {
          new ParDef("@FlightId",GXType.Int16,4,0) ,
          new ParDef("@FlightSeatId",GXType.Int16,4,0) ,
          new ParDef("@FlightSeatChar",GXType.NChar,1,0)
          };
          Object[] prmT00063;
          prmT00063 = new Object[] {
          new ParDef("@FlightId",GXType.Int16,4,0) ,
          new ParDef("@FlightSeatId",GXType.Int16,4,0) ,
          new ParDef("@FlightSeatChar",GXType.NChar,1,0)
          };
          Object[] prmT00064;
          prmT00064 = new Object[] {
          new ParDef("@FlightId",GXType.Int16,4,0)
          };
          Object[] prmT00065;
          prmT00065 = new Object[] {
          new ParDef("@FlightId",GXType.Int16,4,0)
          };
          Object[] prmT00066;
          prmT00066 = new Object[] {
          new ParDef("@AirlineId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT00067;
          prmT00067 = new Object[] {
          new ParDef("@FlightDepartureAirportId",GXType.Int16,4,0)
          };
          Object[] prmT00068;
          prmT00068 = new Object[] {
          new ParDef("@FlightArrivalAirportId",GXType.Int16,4,0)
          };
          Object[] prmT00069;
          prmT00069 = new Object[] {
          new ParDef("@FlightDepartureCountryId",GXType.Int16,4,0)
          };
          Object[] prmT000610;
          prmT000610 = new Object[] {
          new ParDef("@FlightDepartureCountryId",GXType.Int16,4,0) ,
          new ParDef("@FlightDepartureCityId",GXType.Int16,4,0)
          };
          Object[] prmT000611;
          prmT000611 = new Object[] {
          new ParDef("@FlightArrivalCountryId",GXType.Int16,4,0)
          };
          Object[] prmT000612;
          prmT000612 = new Object[] {
          new ParDef("@FlightArrivalCountryId",GXType.Int16,4,0) ,
          new ParDef("@FlightArrivalCityId",GXType.Int16,4,0)
          };
          Object[] prmT000614;
          prmT000614 = new Object[] {
          new ParDef("@FlightId",GXType.Int16,4,0)
          };
          Object[] prmT000616;
          prmT000616 = new Object[] {
          new ParDef("@FlightId",GXType.Int16,4,0)
          };
          Object[] prmT000618;
          prmT000618 = new Object[] {
          new ParDef("@FlightId",GXType.Int16,4,0)
          };
          Object[] prmT000619;
          prmT000619 = new Object[] {
          new ParDef("@FlightDepartureAirportId",GXType.Int16,4,0)
          };
          Object[] prmT000620;
          prmT000620 = new Object[] {
          new ParDef("@FlightDepartureCountryId",GXType.Int16,4,0)
          };
          Object[] prmT000621;
          prmT000621 = new Object[] {
          new ParDef("@FlightDepartureCountryId",GXType.Int16,4,0) ,
          new ParDef("@FlightDepartureCityId",GXType.Int16,4,0)
          };
          Object[] prmT000622;
          prmT000622 = new Object[] {
          new ParDef("@FlightArrivalAirportId",GXType.Int16,4,0)
          };
          Object[] prmT000623;
          prmT000623 = new Object[] {
          new ParDef("@FlightArrivalCountryId",GXType.Int16,4,0)
          };
          Object[] prmT000624;
          prmT000624 = new Object[] {
          new ParDef("@FlightArrivalCountryId",GXType.Int16,4,0) ,
          new ParDef("@FlightArrivalCityId",GXType.Int16,4,0)
          };
          Object[] prmT000625;
          prmT000625 = new Object[] {
          new ParDef("@AirlineId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000626;
          prmT000626 = new Object[] {
          new ParDef("@FlightId",GXType.Int16,4,0)
          };
          Object[] prmT000627;
          prmT000627 = new Object[] {
          new ParDef("@FlightId",GXType.Int16,4,0)
          };
          Object[] prmT000628;
          prmT000628 = new Object[] {
          new ParDef("@FlightId",GXType.Int16,4,0)
          };
          Object[] prmT000629;
          prmT000629 = new Object[] {
          new ParDef("@FlightPrice",GXType.Decimal,9,2) ,
          new ParDef("@FlightDiscountPercentage",GXType.Int16,3,0) ,
          new ParDef("@AirlineId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@FlightDepartureAirportId",GXType.Int16,4,0) ,
          new ParDef("@FlightArrivalAirportId",GXType.Int16,4,0)
          };
          Object[] prmT000630;
          prmT000630 = new Object[] {
          new ParDef("@FlightPrice",GXType.Decimal,9,2) ,
          new ParDef("@FlightDiscountPercentage",GXType.Int16,3,0) ,
          new ParDef("@AirlineId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@FlightDepartureAirportId",GXType.Int16,4,0) ,
          new ParDef("@FlightArrivalAirportId",GXType.Int16,4,0) ,
          new ParDef("@FlightId",GXType.Int16,4,0)
          };
          Object[] prmT000631;
          prmT000631 = new Object[] {
          new ParDef("@FlightId",GXType.Int16,4,0)
          };
          Object[] prmT000633;
          prmT000633 = new Object[] {
          new ParDef("@FlightId",GXType.Int16,4,0)
          };
          Object[] prmT000634;
          prmT000634 = new Object[] {
          new ParDef("@FlightDepartureAirportId",GXType.Int16,4,0)
          };
          Object[] prmT000635;
          prmT000635 = new Object[] {
          new ParDef("@FlightDepartureCountryId",GXType.Int16,4,0)
          };
          Object[] prmT000636;
          prmT000636 = new Object[] {
          new ParDef("@FlightDepartureCountryId",GXType.Int16,4,0) ,
          new ParDef("@FlightDepartureCityId",GXType.Int16,4,0)
          };
          Object[] prmT000637;
          prmT000637 = new Object[] {
          new ParDef("@FlightArrivalAirportId",GXType.Int16,4,0)
          };
          Object[] prmT000638;
          prmT000638 = new Object[] {
          new ParDef("@FlightArrivalCountryId",GXType.Int16,4,0)
          };
          Object[] prmT000639;
          prmT000639 = new Object[] {
          new ParDef("@FlightArrivalCountryId",GXType.Int16,4,0) ,
          new ParDef("@FlightArrivalCityId",GXType.Int16,4,0)
          };
          Object[] prmT000640;
          prmT000640 = new Object[] {
          new ParDef("@AirlineId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000641;
          prmT000641 = new Object[] {
          };
          Object[] prmT000642;
          prmT000642 = new Object[] {
          new ParDef("@FlightId",GXType.Int16,4,0) ,
          new ParDef("@FlightSeatId",GXType.Int16,4,0) ,
          new ParDef("@FlightSeatChar",GXType.NChar,1,0)
          };
          Object[] prmT000643;
          prmT000643 = new Object[] {
          new ParDef("@FlightId",GXType.Int16,4,0) ,
          new ParDef("@FlightSeatId",GXType.Int16,4,0) ,
          new ParDef("@FlightSeatChar",GXType.NChar,1,0)
          };
          Object[] prmT000644;
          prmT000644 = new Object[] {
          new ParDef("@FlightId",GXType.Int16,4,0) ,
          new ParDef("@FlightSeatId",GXType.Int16,4,0) ,
          new ParDef("@FlightSeatChar",GXType.NChar,1,0) ,
          new ParDef("@FlightSeatLocation",GXType.NChar,1,0)
          };
          Object[] prmT000645;
          prmT000645 = new Object[] {
          new ParDef("@FlightSeatLocation",GXType.NChar,1,0) ,
          new ParDef("@FlightId",GXType.Int16,4,0) ,
          new ParDef("@FlightSeatId",GXType.Int16,4,0) ,
          new ParDef("@FlightSeatChar",GXType.NChar,1,0)
          };
          Object[] prmT000646;
          prmT000646 = new Object[] {
          new ParDef("@FlightId",GXType.Int16,4,0) ,
          new ParDef("@FlightSeatId",GXType.Int16,4,0) ,
          new ParDef("@FlightSeatChar",GXType.NChar,1,0)
          };
          Object[] prmT000647;
          prmT000647 = new Object[] {
          new ParDef("@FlightId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00062", "SELECT [FlightId], [FlightSeatId], [FlightSeatChar], [FlightSeatLocation] FROM [FlightSeat] WITH (UPDLOCK) WHERE [FlightId] = @FlightId AND [FlightSeatId] = @FlightSeatId AND [FlightSeatChar] = @FlightSeatChar ",true, GxErrorMask.GX_NOMASK, false, this,prmT00062,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00063", "SELECT [FlightId], [FlightSeatId], [FlightSeatChar], [FlightSeatLocation] FROM [FlightSeat] WHERE [FlightId] = @FlightId AND [FlightSeatId] = @FlightSeatId AND [FlightSeatChar] = @FlightSeatChar ",true, GxErrorMask.GX_NOMASK, false, this,prmT00063,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00064", "SELECT [FlightId], [FlightPrice], [FlightDiscountPercentage], [AirlineId], [FlightDepartureAirportId] AS FlightDepartureAirportId, [FlightArrivalAirportId] AS FlightArrivalAirportId FROM [Flight] WITH (UPDLOCK) WHERE [FlightId] = @FlightId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00064,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00065", "SELECT [FlightId], [FlightPrice], [FlightDiscountPercentage], [AirlineId], [FlightDepartureAirportId] AS FlightDepartureAirportId, [FlightArrivalAirportId] AS FlightArrivalAirportId FROM [Flight] WHERE [FlightId] = @FlightId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00065,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00066", "SELECT [AirlineName], [AirlineDiscountPercentage] FROM [Airline] WHERE [AirlineId] = @AirlineId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00066,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00067", "SELECT [AirPortName] AS FlightDepartureAirportName, [CountryId] AS FlightDepartureCountryId, [CityId] AS FlightDepartureCityId FROM [Airport] WHERE [AirportId] = @FlightDepartureAirportId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00067,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00068", "SELECT [AirPortName] AS FlightArrivalAirportName, [CountryId] AS FlightArrivalCountryId, [CityId] AS FlightArrivalCityId FROM [Airport] WHERE [AirportId] = @FlightArrivalAirportId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00068,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00069", "SELECT [CountryName] AS FlightDepartureCountryName FROM [Country] WHERE [CountryId] = @FlightDepartureCountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00069,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000610", "SELECT [CityName] AS FlightDepartureCityName FROM [CountryCity] WHERE [CountryId] = @FlightDepartureCountryId AND [CityId] = @FlightDepartureCityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000610,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000611", "SELECT [CountryName] AS FlightArrivalCountryName FROM [Country] WHERE [CountryId] = @FlightArrivalCountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000611,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000612", "SELECT [CityName] AS FlightArrivalCityName FROM [CountryCity] WHERE [CountryId] = @FlightArrivalCountryId AND [CityId] = @FlightArrivalCityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000612,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000614", "SELECT COALESCE( T1.[FlightCapacity], 0) AS FlightCapacity FROM (SELECT COUNT(*) AS FlightCapacity, [FlightId] FROM [FlightSeat] WITH (UPDLOCK) GROUP BY [FlightId] ) T1 WHERE T1.[FlightId] = @FlightId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000614,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000616", "SELECT TM1.[FlightId], T3.[AirPortName] AS FlightDepartureAirportName, T4.[CountryName] AS FlightDepartureCountryName, T5.[CityName] AS FlightDepartureCityName, T6.[AirPortName] AS FlightArrivalAirportName, T7.[CountryName] AS FlightArrivalCountryName, T8.[CityName] AS FlightArrivalCityName, TM1.[FlightPrice], TM1.[FlightDiscountPercentage], T9.[AirlineName], T9.[AirlineDiscountPercentage], TM1.[AirlineId], TM1.[FlightDepartureAirportId] AS FlightDepartureAirportId, TM1.[FlightArrivalAirportId] AS FlightArrivalAirportId, T3.[CountryId] AS FlightDepartureCountryId, T3.[CityId] AS FlightDepartureCityId, T6.[CountryId] AS FlightArrivalCountryId, T6.[CityId] AS FlightArrivalCityId, COALESCE( T2.[FlightCapacity], 0) AS FlightCapacity FROM (((((((([Flight] TM1 LEFT JOIN (SELECT COUNT(*) AS FlightCapacity, [FlightId] FROM [FlightSeat] GROUP BY [FlightId] ) T2 ON T2.[FlightId] = TM1.[FlightId]) INNER JOIN [Airport] T3 ON T3.[AirportId] = TM1.[FlightDepartureAirportId]) INNER JOIN [Country] T4 ON T4.[CountryId] = T3.[CountryId]) INNER JOIN [CountryCity] T5 ON T5.[CountryId] = T3.[CountryId] AND T5.[CityId] = T3.[CityId]) INNER JOIN [Airport] T6 ON T6.[AirportId] = TM1.[FlightArrivalAirportId]) INNER JOIN [Country] T7 ON T7.[CountryId] = T6.[CountryId]) INNER JOIN [CountryCity] T8 ON T8.[CountryId] = T6.[CountryId] AND T8.[CityId] = T6.[CityId]) LEFT JOIN [Airline] T9 ON T9.[AirlineId] = TM1.[AirlineId]) WHERE TM1.[FlightId] = @FlightId ORDER BY TM1.[FlightId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000616,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000618", "SELECT COALESCE( T1.[FlightCapacity], 0) AS FlightCapacity FROM (SELECT COUNT(*) AS FlightCapacity, [FlightId] FROM [FlightSeat] WITH (UPDLOCK) GROUP BY [FlightId] ) T1 WHERE T1.[FlightId] = @FlightId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000618,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000619", "SELECT [AirPortName] AS FlightDepartureAirportName, [CountryId] AS FlightDepartureCountryId, [CityId] AS FlightDepartureCityId FROM [Airport] WHERE [AirportId] = @FlightDepartureAirportId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000619,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000620", "SELECT [CountryName] AS FlightDepartureCountryName FROM [Country] WHERE [CountryId] = @FlightDepartureCountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000620,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000621", "SELECT [CityName] AS FlightDepartureCityName FROM [CountryCity] WHERE [CountryId] = @FlightDepartureCountryId AND [CityId] = @FlightDepartureCityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000621,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000622", "SELECT [AirPortName] AS FlightArrivalAirportName, [CountryId] AS FlightArrivalCountryId, [CityId] AS FlightArrivalCityId FROM [Airport] WHERE [AirportId] = @FlightArrivalAirportId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000622,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000623", "SELECT [CountryName] AS FlightArrivalCountryName FROM [Country] WHERE [CountryId] = @FlightArrivalCountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000623,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000624", "SELECT [CityName] AS FlightArrivalCityName FROM [CountryCity] WHERE [CountryId] = @FlightArrivalCountryId AND [CityId] = @FlightArrivalCityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000624,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000625", "SELECT [AirlineName], [AirlineDiscountPercentage] FROM [Airline] WHERE [AirlineId] = @AirlineId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000625,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000626", "SELECT [FlightId] FROM [Flight] WHERE [FlightId] = @FlightId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000626,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000627", "SELECT TOP 1 [FlightId] FROM [Flight] WHERE ( [FlightId] > @FlightId) ORDER BY [FlightId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000627,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000628", "SELECT TOP 1 [FlightId] FROM [Flight] WHERE ( [FlightId] < @FlightId) ORDER BY [FlightId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000628,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000629", "INSERT INTO [Flight]([FlightPrice], [FlightDiscountPercentage], [AirlineId], [FlightDepartureAirportId], [FlightArrivalAirportId]) VALUES(@FlightPrice, @FlightDiscountPercentage, @AirlineId, @FlightDepartureAirportId, @FlightArrivalAirportId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000629,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000630", "UPDATE [Flight] SET [FlightPrice]=@FlightPrice, [FlightDiscountPercentage]=@FlightDiscountPercentage, [AirlineId]=@AirlineId, [FlightDepartureAirportId]=@FlightDepartureAirportId, [FlightArrivalAirportId]=@FlightArrivalAirportId  WHERE [FlightId] = @FlightId", GxErrorMask.GX_NOMASK,prmT000630)
             ,new CursorDef("T000631", "DELETE FROM [Flight]  WHERE [FlightId] = @FlightId", GxErrorMask.GX_NOMASK,prmT000631)
             ,new CursorDef("T000633", "SELECT COALESCE( T1.[FlightCapacity], 0) AS FlightCapacity FROM (SELECT COUNT(*) AS FlightCapacity, [FlightId] FROM [FlightSeat] WITH (UPDLOCK) GROUP BY [FlightId] ) T1 WHERE T1.[FlightId] = @FlightId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000633,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000634", "SELECT [AirPortName] AS FlightDepartureAirportName, [CountryId] AS FlightDepartureCountryId, [CityId] AS FlightDepartureCityId FROM [Airport] WHERE [AirportId] = @FlightDepartureAirportId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000634,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000635", "SELECT [CountryName] AS FlightDepartureCountryName FROM [Country] WHERE [CountryId] = @FlightDepartureCountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000635,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000636", "SELECT [CityName] AS FlightDepartureCityName FROM [CountryCity] WHERE [CountryId] = @FlightDepartureCountryId AND [CityId] = @FlightDepartureCityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000636,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000637", "SELECT [AirPortName] AS FlightArrivalAirportName, [CountryId] AS FlightArrivalCountryId, [CityId] AS FlightArrivalCityId FROM [Airport] WHERE [AirportId] = @FlightArrivalAirportId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000637,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000638", "SELECT [CountryName] AS FlightArrivalCountryName FROM [Country] WHERE [CountryId] = @FlightArrivalCountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000638,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000639", "SELECT [CityName] AS FlightArrivalCityName FROM [CountryCity] WHERE [CountryId] = @FlightArrivalCountryId AND [CityId] = @FlightArrivalCityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000639,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000640", "SELECT [AirlineName], [AirlineDiscountPercentage] FROM [Airline] WHERE [AirlineId] = @AirlineId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000640,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000641", "SELECT [FlightId] FROM [Flight] ORDER BY [FlightId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000641,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000642", "SELECT [FlightId], [FlightSeatId], [FlightSeatChar], [FlightSeatLocation] FROM [FlightSeat] WHERE [FlightId] = @FlightId and [FlightSeatId] = @FlightSeatId and [FlightSeatChar] = @FlightSeatChar ORDER BY [FlightId], [FlightSeatId], [FlightSeatChar] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000642,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000643", "SELECT [FlightId], [FlightSeatId], [FlightSeatChar] FROM [FlightSeat] WHERE [FlightId] = @FlightId AND [FlightSeatId] = @FlightSeatId AND [FlightSeatChar] = @FlightSeatChar ",true, GxErrorMask.GX_NOMASK, false, this,prmT000643,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000644", "INSERT INTO [FlightSeat]([FlightId], [FlightSeatId], [FlightSeatChar], [FlightSeatLocation]) VALUES(@FlightId, @FlightSeatId, @FlightSeatChar, @FlightSeatLocation)", GxErrorMask.GX_NOMASK,prmT000644)
             ,new CursorDef("T000645", "UPDATE [FlightSeat] SET [FlightSeatLocation]=@FlightSeatLocation  WHERE [FlightId] = @FlightId AND [FlightSeatId] = @FlightSeatId AND [FlightSeatChar] = @FlightSeatChar", GxErrorMask.GX_NOMASK,prmT000645)
             ,new CursorDef("T000646", "DELETE FROM [FlightSeat]  WHERE [FlightId] = @FlightId AND [FlightSeatId] = @FlightSeatId AND [FlightSeatChar] = @FlightSeatChar", GxErrorMask.GX_NOMASK,prmT000646)
             ,new CursorDef("T000647", "SELECT [FlightId], [FlightSeatId], [FlightSeatChar] FROM [FlightSeat] WHERE [FlightId] = @FlightId ORDER BY [FlightId], [FlightSeatId], [FlightSeatChar] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000647,11, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((short[]) buf[5])[0] = rslt.getShort(5);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((short[]) buf[5])[0] = rslt.getShort(5);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 9 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 10 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 11 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                ((string[]) buf[2])[0] = rslt.getString(3, 50);
                ((string[]) buf[3])[0] = rslt.getString(4, 50);
                ((string[]) buf[4])[0] = rslt.getString(5, 50);
                ((string[]) buf[5])[0] = rslt.getString(6, 50);
                ((string[]) buf[6])[0] = rslt.getString(7, 50);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((short[]) buf[8])[0] = rslt.getShort(9);
                ((string[]) buf[9])[0] = rslt.getString(10, 50);
                ((short[]) buf[10])[0] = rslt.getShort(11);
                ((short[]) buf[11])[0] = rslt.getShort(12);
                ((bool[]) buf[12])[0] = rslt.wasNull(12);
                ((short[]) buf[13])[0] = rslt.getShort(13);
                ((short[]) buf[14])[0] = rslt.getShort(14);
                ((short[]) buf[15])[0] = rslt.getShort(15);
                ((short[]) buf[16])[0] = rslt.getShort(16);
                ((short[]) buf[17])[0] = rslt.getShort(17);
                ((short[]) buf[18])[0] = rslt.getShort(18);
                ((short[]) buf[19])[0] = rslt.getShort(19);
                ((bool[]) buf[20])[0] = rslt.wasNull(19);
                return;
             case 13 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 14 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 15 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 16 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 17 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 18 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 19 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 20 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 21 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 22 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 23 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 24 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 27 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 28 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 29 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
       }
       getresults30( cursor, rslt, buf) ;
    }

    public void getresults30( int cursor ,
                              IFieldGetter rslt ,
                              Object[] buf )
    {
       switch ( cursor )
       {
             case 30 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 31 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 32 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 33 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 34 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 35 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 36 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                return;
             case 37 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                return;
             case 41 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                return;
       }
    }

 }

}
