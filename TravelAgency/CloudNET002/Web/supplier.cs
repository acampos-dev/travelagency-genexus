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
   public class supplier : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
         {
            A7AttractionId = (short)(Math.Round(NumberUtil.Val( GetPar( "AttractionId"), "."), 18, MidpointRounding.ToEven));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A7AttractionId) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridsupplier_attraction") == 0 )
         {
            gxnrGridsupplier_attraction_newrow_invoke( ) ;
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
         Form.Meta.addItem("description", "Supplier", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtSupplierId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("TravelAgency", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridsupplier_attraction_newrow_invoke( )
      {
         nRC_GXsfl_53 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_53"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_53_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_53_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_53_idx = GetPar( "sGXsfl_53_idx");
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridsupplier_attraction_newrow( ) ;
         /* End function gxnrGridsupplier_attraction_newrow_invoke */
      }

      public supplier( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("TravelAgency", true);
      }

      public supplier( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Supplier", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Supplier.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Supplier.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Supplier.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Supplier.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Supplier.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 4, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx00a0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"SUPPLIERID"+"'), id:'"+"SUPPLIERID"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_Supplier.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A45SupplierId), 4, 0, ".", "")), StringUtil.LTrim( ((edtSupplierId_Enabled!=0) ? context.localUtil.Format( (decimal)(A45SupplierId), "ZZZ9") : context.localUtil.Format( (decimal)(A45SupplierId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Supplier.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierName_Internalname, "Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierName_Internalname, StringUtil.RTrim( A46SupplierName), StringUtil.RTrim( context.localUtil.Format( A46SupplierName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierName_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Supplier.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupplierAddress_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierAddress_Internalname, "Address", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtSupplierAddress_Internalname, A47SupplierAddress, "http://maps.google.com/maps?q="+GXUtil.UrlEncode( A47SupplierAddress), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", 0, 1, edtSupplierAddress_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "1024", -1, 0, "_blank", "", 0, true, "GeneXus\\Address", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Supplier.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divAttractiontable_Internalname, 1, 0, "px", 0, "px", "form__table-level", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitleattraction_Internalname, "Attraction", "", "", lblTitleattraction_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-04", 0, "", 1, 1, 0, 0, "HLP_Supplier.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         gxdraw_Gridsupplier_attraction( ) ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirm", bttBtn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Supplier.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Supplier.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Supplier.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "end", "Middle", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void gxdraw_Gridsupplier_attraction( )
      {
         /*  Grid Control  */
         StartGridControl53( ) ;
         nGXsfl_53_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount11 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_11 = 1;
               ScanStart0811( ) ;
               while ( RcdFound11 != 0 )
               {
                  init_level_properties11( ) ;
                  getByPrimaryKey0811( ) ;
                  AddRow0811( ) ;
                  ScanNext0811( ) ;
               }
               ScanEnd0811( ) ;
               nBlankRcdCount11 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal0811( ) ;
            standaloneModal0811( ) ;
            sMode11 = Gx_mode;
            while ( nGXsfl_53_idx < nRC_GXsfl_53 )
            {
               bGXsfl_53_Refreshing = true;
               ReadRow0811( ) ;
               edtAttractionId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ATTRACTIONID_"+sGXsfl_53_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtAttractionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAttractionId_Enabled), 5, 0), !bGXsfl_53_Refreshing);
               edtAttractionName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ATTRACTIONNAME_"+sGXsfl_53_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtAttractionName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAttractionName_Enabled), 5, 0), !bGXsfl_53_Refreshing);
               edtAttractionPhoto_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ATTRACTIONPHOTO_"+sGXsfl_53_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtAttractionPhoto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAttractionPhoto_Enabled), 5, 0), !bGXsfl_53_Refreshing);
               edtSupplierAttractionDate_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SUPPLIERATTRACTIONDATE_"+sGXsfl_53_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtSupplierAttractionDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierAttractionDate_Enabled), 5, 0), !bGXsfl_53_Refreshing);
               imgprompt_7_Link = cgiGet( "PROMPT_7_"+sGXsfl_53_idx+"Link");
               if ( ( nRcdExists_11 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0811( ) ;
               }
               SendRow0811( ) ;
               bGXsfl_53_Refreshing = false;
            }
            Gx_mode = sMode11;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount11 = 5;
            nRcdExists_11 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0811( ) ;
               while ( RcdFound11 != 0 )
               {
                  sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_5311( ) ;
                  init_level_properties11( ) ;
                  standaloneNotModal0811( ) ;
                  getByPrimaryKey0811( ) ;
                  standaloneModal0811( ) ;
                  AddRow0811( ) ;
                  ScanNext0811( ) ;
               }
               ScanEnd0811( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         sMode11 = Gx_mode;
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx+1), 4, 0), 4, "0");
         SubsflControlProps_5311( ) ;
         InitAll0811( ) ;
         init_level_properties11( ) ;
         nRcdExists_11 = 0;
         nIsMod_11 = 0;
         nRcdDeleted_11 = 0;
         nBlankRcdCount11 = (short)(nBlankRcdUsr11+nBlankRcdCount11);
         fRowAdded = 0;
         while ( nBlankRcdCount11 > 0 )
         {
            standaloneNotModal0811( ) ;
            standaloneModal0811( ) ;
            AddRow0811( ) ;
            if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
            {
               fRowAdded = 1;
               GX_FocusControl = edtAttractionId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nBlankRcdCount11 = (short)(nBlankRcdCount11-1);
         }
         Gx_mode = sMode11;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridsupplier_attractionContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridsupplier_attraction", Gridsupplier_attractionContainer, subGridsupplier_attraction_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridsupplier_attractionContainerData", Gridsupplier_attractionContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridsupplier_attractionContainerData"+"V", Gridsupplier_attractionContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridsupplier_attractionContainerData"+"V"+"\" value='"+Gridsupplier_attractionContainer.GridValuesHidden()+"'/>") ;
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
            Z45SupplierId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z45SupplierId"), ".", ","), 18, MidpointRounding.ToEven));
            Z46SupplierName = cgiGet( "Z46SupplierName");
            Z47SupplierAddress = cgiGet( "Z47SupplierAddress");
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            nRC_GXsfl_53 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_53"), ".", ","), 18, MidpointRounding.ToEven));
            A40000AttractionPhoto_GXI = cgiGet( "ATTRACTIONPHOTO_GXI");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtSupplierId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSupplierId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SUPPLIERID");
               AnyError = 1;
               GX_FocusControl = edtSupplierId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A45SupplierId = 0;
               AssignAttri("", false, "A45SupplierId", StringUtil.LTrimStr( (decimal)(A45SupplierId), 4, 0));
            }
            else
            {
               A45SupplierId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtSupplierId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A45SupplierId", StringUtil.LTrimStr( (decimal)(A45SupplierId), 4, 0));
            }
            A46SupplierName = cgiGet( edtSupplierName_Internalname);
            AssignAttri("", false, "A46SupplierName", A46SupplierName);
            A47SupplierAddress = cgiGet( edtSupplierAddress_Internalname);
            AssignAttri("", false, "A47SupplierAddress", A47SupplierAddress);
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
               A45SupplierId = (short)(Math.Round(NumberUtil.Val( GetPar( "SupplierId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A45SupplierId", StringUtil.LTrimStr( (decimal)(A45SupplierId), 4, 0));
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
               InitAll0810( ) ;
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
         DisableAttributes0810( ) ;
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

      protected void CONFIRM_0811( )
      {
         nGXsfl_53_idx = 0;
         while ( nGXsfl_53_idx < nRC_GXsfl_53 )
         {
            ReadRow0811( ) ;
            if ( ( nRcdExists_11 != 0 ) || ( nIsMod_11 != 0 ) )
            {
               GetKey0811( ) ;
               if ( ( nRcdExists_11 == 0 ) && ( nRcdDeleted_11 == 0 ) )
               {
                  if ( RcdFound11 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate0811( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0811( ) ;
                        CloseExtendedTableCursors0811( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "ATTRACTIONID_" + sGXsfl_53_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtAttractionId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound11 != 0 )
                  {
                     if ( nRcdDeleted_11 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0811( ) ;
                        Load0811( ) ;
                        BeforeValidate0811( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0811( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_11 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate0811( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0811( ) ;
                              CloseExtendedTableCursors0811( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_11 == 0 )
                     {
                        GXCCtl = "ATTRACTIONID_" + sGXsfl_53_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtAttractionId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtAttractionId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A7AttractionId), 4, 0, ".", ""))) ;
            ChangePostValue( edtAttractionName_Internalname, StringUtil.RTrim( A8AttractionName)) ;
            ChangePostValue( edtAttractionPhoto_Internalname, A13AttractionPhoto) ;
            ChangePostValue( edtSupplierAttractionDate_Internalname, context.localUtil.Format(A48SupplierAttractionDate, "99/99/99")) ;
            ChangePostValue( "ZT_"+"Z7AttractionId_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z7AttractionId), 4, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z48SupplierAttractionDate_"+sGXsfl_53_idx, context.localUtil.DToC( Z48SupplierAttractionDate, 0, "/")) ;
            ChangePostValue( "nRcdDeleted_11_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_11), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_11_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_11), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_11_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_11), 4, 0, ".", ""))) ;
            if ( nIsMod_11 != 0 )
            {
               ChangePostValue( "ATTRACTIONID_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAttractionId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ATTRACTIONNAME_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAttractionName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ATTRACTIONPHOTO_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAttractionPhoto_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SUPPLIERATTRACTIONDATE_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplierAttractionDate_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption080( )
      {
      }

      protected void ZM0810( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z46SupplierName = T00086_A46SupplierName[0];
               Z47SupplierAddress = T00086_A47SupplierAddress[0];
            }
            else
            {
               Z46SupplierName = A46SupplierName;
               Z47SupplierAddress = A47SupplierAddress;
            }
         }
         if ( GX_JID == -2 )
         {
            Z45SupplierId = A45SupplierId;
            Z46SupplierName = A46SupplierName;
            Z47SupplierAddress = A47SupplierAddress;
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

      protected void Load0810( )
      {
         /* Using cursor T00087 */
         pr_default.execute(5, new Object[] {A45SupplierId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound10 = 1;
            A46SupplierName = T00087_A46SupplierName[0];
            AssignAttri("", false, "A46SupplierName", A46SupplierName);
            A47SupplierAddress = T00087_A47SupplierAddress[0];
            AssignAttri("", false, "A47SupplierAddress", A47SupplierAddress);
            ZM0810( -2) ;
         }
         pr_default.close(5);
         OnLoadActions0810( ) ;
      }

      protected void OnLoadActions0810( )
      {
      }

      protected void CheckExtendedTable0810( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors0810( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0810( )
      {
         /* Using cursor T00088 */
         pr_default.execute(6, new Object[] {A45SupplierId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound10 = 1;
         }
         else
         {
            RcdFound10 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00086 */
         pr_default.execute(4, new Object[] {A45SupplierId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            ZM0810( 2) ;
            RcdFound10 = 1;
            A45SupplierId = T00086_A45SupplierId[0];
            AssignAttri("", false, "A45SupplierId", StringUtil.LTrimStr( (decimal)(A45SupplierId), 4, 0));
            A46SupplierName = T00086_A46SupplierName[0];
            AssignAttri("", false, "A46SupplierName", A46SupplierName);
            A47SupplierAddress = T00086_A47SupplierAddress[0];
            AssignAttri("", false, "A47SupplierAddress", A47SupplierAddress);
            Z45SupplierId = A45SupplierId;
            sMode10 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0810( ) ;
            if ( AnyError == 1 )
            {
               RcdFound10 = 0;
               InitializeNonKey0810( ) ;
            }
            Gx_mode = sMode10;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound10 = 0;
            InitializeNonKey0810( ) ;
            sMode10 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode10;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(4);
      }

      protected void getEqualNoModal( )
      {
         GetKey0810( ) ;
         if ( RcdFound10 == 0 )
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
         RcdFound10 = 0;
         /* Using cursor T00089 */
         pr_default.execute(7, new Object[] {A45SupplierId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00089_A45SupplierId[0] < A45SupplierId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00089_A45SupplierId[0] > A45SupplierId ) ) )
            {
               A45SupplierId = T00089_A45SupplierId[0];
               AssignAttri("", false, "A45SupplierId", StringUtil.LTrimStr( (decimal)(A45SupplierId), 4, 0));
               RcdFound10 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void move_previous( )
      {
         RcdFound10 = 0;
         /* Using cursor T000810 */
         pr_default.execute(8, new Object[] {A45SupplierId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000810_A45SupplierId[0] > A45SupplierId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000810_A45SupplierId[0] < A45SupplierId ) ) )
            {
               A45SupplierId = T000810_A45SupplierId[0];
               AssignAttri("", false, "A45SupplierId", StringUtil.LTrimStr( (decimal)(A45SupplierId), 4, 0));
               RcdFound10 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0810( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtSupplierId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0810( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound10 == 1 )
            {
               if ( A45SupplierId != Z45SupplierId )
               {
                  A45SupplierId = Z45SupplierId;
                  AssignAttri("", false, "A45SupplierId", StringUtil.LTrimStr( (decimal)(A45SupplierId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "SUPPLIERID");
                  AnyError = 1;
                  GX_FocusControl = edtSupplierId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtSupplierId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0810( ) ;
                  GX_FocusControl = edtSupplierId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A45SupplierId != Z45SupplierId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtSupplierId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0810( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "SUPPLIERID");
                     AnyError = 1;
                     GX_FocusControl = edtSupplierId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtSupplierId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0810( ) ;
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
         if ( A45SupplierId != Z45SupplierId )
         {
            A45SupplierId = Z45SupplierId;
            AssignAttri("", false, "A45SupplierId", StringUtil.LTrimStr( (decimal)(A45SupplierId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "SUPPLIERID");
            AnyError = 1;
            GX_FocusControl = edtSupplierId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtSupplierId_Internalname;
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
         if ( RcdFound10 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "SUPPLIERID");
            AnyError = 1;
            GX_FocusControl = edtSupplierId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtSupplierName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0810( ) ;
         if ( RcdFound10 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSupplierName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0810( ) ;
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
         if ( RcdFound10 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSupplierName_Internalname;
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
         if ( RcdFound10 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSupplierName_Internalname;
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
         ScanStart0810( ) ;
         if ( RcdFound10 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound10 != 0 )
            {
               ScanNext0810( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSupplierName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0810( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0810( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00085 */
            pr_default.execute(3, new Object[] {A45SupplierId});
            if ( (pr_default.getStatus(3) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Supplier"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(3) == 101) || ( StringUtil.StrCmp(Z46SupplierName, T00085_A46SupplierName[0]) != 0 ) || ( StringUtil.StrCmp(Z47SupplierAddress, T00085_A47SupplierAddress[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z46SupplierName, T00085_A46SupplierName[0]) != 0 )
               {
                  GXUtil.WriteLog("supplier:[seudo value changed for attri]"+"SupplierName");
                  GXUtil.WriteLogRaw("Old: ",Z46SupplierName);
                  GXUtil.WriteLogRaw("Current: ",T00085_A46SupplierName[0]);
               }
               if ( StringUtil.StrCmp(Z47SupplierAddress, T00085_A47SupplierAddress[0]) != 0 )
               {
                  GXUtil.WriteLog("supplier:[seudo value changed for attri]"+"SupplierAddress");
                  GXUtil.WriteLogRaw("Old: ",Z47SupplierAddress);
                  GXUtil.WriteLogRaw("Current: ",T00085_A47SupplierAddress[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Supplier"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0810( )
      {
         BeforeValidate0810( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0810( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0810( 0) ;
            CheckOptimisticConcurrency0810( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0810( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0810( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000811 */
                     pr_default.execute(9, new Object[] {A46SupplierName, A47SupplierAddress});
                     A45SupplierId = T000811_A45SupplierId[0];
                     AssignAttri("", false, "A45SupplierId", StringUtil.LTrimStr( (decimal)(A45SupplierId), 4, 0));
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Supplier");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0810( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption080( ) ;
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
               Load0810( ) ;
            }
            EndLevel0810( ) ;
         }
         CloseExtendedTableCursors0810( ) ;
      }

      protected void Update0810( )
      {
         BeforeValidate0810( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0810( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0810( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0810( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0810( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000812 */
                     pr_default.execute(10, new Object[] {A46SupplierName, A47SupplierAddress, A45SupplierId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Supplier");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Supplier"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0810( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0810( ) ;
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey( ) ;
                              endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                              endTrnMsgCod = "SuccessfullyUpdated";
                              ResetCaption080( ) ;
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
            EndLevel0810( ) ;
         }
         CloseExtendedTableCursors0810( ) ;
      }

      protected void DeferredUpdate0810( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0810( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0810( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0810( ) ;
            AfterConfirm0810( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0810( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart0811( ) ;
                  while ( RcdFound11 != 0 )
                  {
                     getByPrimaryKey0811( ) ;
                     Delete0811( ) ;
                     ScanNext0811( ) ;
                  }
                  ScanEnd0811( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000813 */
                     pr_default.execute(11, new Object[] {A45SupplierId});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("Supplier");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        /* End of After( delete) rules */
                        if ( AnyError == 0 )
                        {
                           move_next( ) ;
                           if ( RcdFound10 == 0 )
                           {
                              InitAll0810( ) ;
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
                           ResetCaption080( ) ;
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
         sMode10 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0810( ) ;
         Gx_mode = sMode10;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0810( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void ProcessNestedLevel0811( )
      {
         nGXsfl_53_idx = 0;
         while ( nGXsfl_53_idx < nRC_GXsfl_53 )
         {
            ReadRow0811( ) ;
            if ( ( nRcdExists_11 != 0 ) || ( nIsMod_11 != 0 ) )
            {
               standaloneNotModal0811( ) ;
               GetKey0811( ) ;
               if ( ( nRcdExists_11 == 0 ) && ( nRcdDeleted_11 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert0811( ) ;
               }
               else
               {
                  if ( RcdFound11 != 0 )
                  {
                     if ( ( nRcdDeleted_11 != 0 ) && ( nRcdExists_11 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete0811( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_11 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update0811( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_11 == 0 )
                     {
                        GXCCtl = "ATTRACTIONID_" + sGXsfl_53_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtAttractionId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtAttractionId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A7AttractionId), 4, 0, ".", ""))) ;
            ChangePostValue( edtAttractionName_Internalname, StringUtil.RTrim( A8AttractionName)) ;
            ChangePostValue( edtAttractionPhoto_Internalname, A13AttractionPhoto) ;
            ChangePostValue( edtSupplierAttractionDate_Internalname, context.localUtil.Format(A48SupplierAttractionDate, "99/99/99")) ;
            ChangePostValue( "ZT_"+"Z7AttractionId_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z7AttractionId), 4, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z48SupplierAttractionDate_"+sGXsfl_53_idx, context.localUtil.DToC( Z48SupplierAttractionDate, 0, "/")) ;
            ChangePostValue( "nRcdDeleted_11_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_11), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_11_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_11), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_11_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_11), 4, 0, ".", ""))) ;
            if ( nIsMod_11 != 0 )
            {
               ChangePostValue( "ATTRACTIONID_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAttractionId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ATTRACTIONNAME_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAttractionName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ATTRACTIONPHOTO_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAttractionPhoto_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SUPPLIERATTRACTIONDATE_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplierAttractionDate_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0811( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_11 = 0;
         nIsMod_11 = 0;
         nRcdDeleted_11 = 0;
      }

      protected void ProcessLevel0810( )
      {
         /* Save parent mode. */
         sMode10 = Gx_mode;
         ProcessNestedLevel0811( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode10;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel0810( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(3);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0810( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(4);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(2);
            context.CommitDataStores("supplier",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues080( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(4);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(2);
            context.RollbackDataStores("supplier",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0810( )
      {
         /* Using cursor T000814 */
         pr_default.execute(12);
         RcdFound10 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound10 = 1;
            A45SupplierId = T000814_A45SupplierId[0];
            AssignAttri("", false, "A45SupplierId", StringUtil.LTrimStr( (decimal)(A45SupplierId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0810( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound10 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound10 = 1;
            A45SupplierId = T000814_A45SupplierId[0];
            AssignAttri("", false, "A45SupplierId", StringUtil.LTrimStr( (decimal)(A45SupplierId), 4, 0));
         }
      }

      protected void ScanEnd0810( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm0810( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0810( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0810( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0810( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0810( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0810( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0810( )
      {
         edtSupplierId_Enabled = 0;
         AssignProp("", false, edtSupplierId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierId_Enabled), 5, 0), true);
         edtSupplierName_Enabled = 0;
         AssignProp("", false, edtSupplierName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierName_Enabled), 5, 0), true);
         edtSupplierAddress_Enabled = 0;
         AssignProp("", false, edtSupplierAddress_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierAddress_Enabled), 5, 0), true);
      }

      protected void ZM0811( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z48SupplierAttractionDate = T00083_A48SupplierAttractionDate[0];
            }
            else
            {
               Z48SupplierAttractionDate = A48SupplierAttractionDate;
            }
         }
         if ( GX_JID == -3 )
         {
            Z45SupplierId = A45SupplierId;
            Z48SupplierAttractionDate = A48SupplierAttractionDate;
            Z7AttractionId = A7AttractionId;
            Z8AttractionName = A8AttractionName;
            Z13AttractionPhoto = A13AttractionPhoto;
            Z40000AttractionPhoto_GXI = A40000AttractionPhoto_GXI;
         }
      }

      protected void standaloneNotModal0811( )
      {
      }

      protected void standaloneModal0811( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtAttractionId_Enabled = 0;
            AssignProp("", false, edtAttractionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAttractionId_Enabled), 5, 0), !bGXsfl_53_Refreshing);
         }
         else
         {
            edtAttractionId_Enabled = 1;
            AssignProp("", false, edtAttractionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAttractionId_Enabled), 5, 0), !bGXsfl_53_Refreshing);
         }
      }

      protected void Load0811( )
      {
         /* Using cursor T000815 */
         pr_default.execute(13, new Object[] {A45SupplierId, A7AttractionId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound11 = 1;
            A8AttractionName = T000815_A8AttractionName[0];
            A40000AttractionPhoto_GXI = T000815_A40000AttractionPhoto_GXI[0];
            AssignProp("", false, edtAttractionPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A13AttractionPhoto)) ? A40000AttractionPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A13AttractionPhoto))), !bGXsfl_53_Refreshing);
            AssignProp("", false, edtAttractionPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A13AttractionPhoto), true);
            A48SupplierAttractionDate = T000815_A48SupplierAttractionDate[0];
            A13AttractionPhoto = T000815_A13AttractionPhoto[0];
            AssignProp("", false, edtAttractionPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A13AttractionPhoto)) ? A40000AttractionPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A13AttractionPhoto))), !bGXsfl_53_Refreshing);
            AssignProp("", false, edtAttractionPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A13AttractionPhoto), true);
            ZM0811( -3) ;
         }
         pr_default.close(13);
         OnLoadActions0811( ) ;
      }

      protected void OnLoadActions0811( )
      {
      }

      protected void CheckExtendedTable0811( )
      {
         nIsDirty_11 = 0;
         Gx_BScreen = 1;
         standaloneModal0811( ) ;
         /* Using cursor T00084 */
         pr_default.execute(2, new Object[] {A7AttractionId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "ATTRACTIONID_" + sGXsfl_53_idx;
            GX_msglist.addItem("No matching 'Attractions'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtAttractionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A8AttractionName = T00084_A8AttractionName[0];
         A40000AttractionPhoto_GXI = T00084_A40000AttractionPhoto_GXI[0];
         AssignProp("", false, edtAttractionPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A13AttractionPhoto)) ? A40000AttractionPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A13AttractionPhoto))), !bGXsfl_53_Refreshing);
         AssignProp("", false, edtAttractionPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A13AttractionPhoto), true);
         A13AttractionPhoto = T00084_A13AttractionPhoto[0];
         AssignProp("", false, edtAttractionPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A13AttractionPhoto)) ? A40000AttractionPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A13AttractionPhoto))), !bGXsfl_53_Refreshing);
         AssignProp("", false, edtAttractionPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A13AttractionPhoto), true);
         pr_default.close(2);
         if ( ! ( (DateTime.MinValue==A48SupplierAttractionDate) || ( DateTimeUtil.ResetTime ( A48SupplierAttractionDate ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GXCCtl = "SUPPLIERATTRACTIONDATE_" + sGXsfl_53_idx;
            GX_msglist.addItem("Field Supplier Attraction Date is out of range", "OutOfRange", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtSupplierAttractionDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0811( )
      {
         pr_default.close(2);
      }

      protected void enableDisable0811( )
      {
      }

      protected void gxLoad_4( short A7AttractionId )
      {
         /* Using cursor T000816 */
         pr_default.execute(14, new Object[] {A7AttractionId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GXCCtl = "ATTRACTIONID_" + sGXsfl_53_idx;
            GX_msglist.addItem("No matching 'Attractions'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtAttractionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A8AttractionName = T000816_A8AttractionName[0];
         A40000AttractionPhoto_GXI = T000816_A40000AttractionPhoto_GXI[0];
         AssignProp("", false, edtAttractionPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A13AttractionPhoto)) ? A40000AttractionPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A13AttractionPhoto))), !bGXsfl_53_Refreshing);
         AssignProp("", false, edtAttractionPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A13AttractionPhoto), true);
         A13AttractionPhoto = T000816_A13AttractionPhoto[0];
         AssignProp("", false, edtAttractionPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A13AttractionPhoto)) ? A40000AttractionPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A13AttractionPhoto))), !bGXsfl_53_Refreshing);
         AssignProp("", false, edtAttractionPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A13AttractionPhoto), true);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A8AttractionName))+"\""+","+"\""+GXUtil.EncodeJSConstant( A13AttractionPhoto)+"\""+","+"\""+GXUtil.EncodeJSConstant( A40000AttractionPhoto_GXI)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(14) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(14);
      }

      protected void GetKey0811( )
      {
         /* Using cursor T000817 */
         pr_default.execute(15, new Object[] {A45SupplierId, A7AttractionId});
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound11 = 1;
         }
         else
         {
            RcdFound11 = 0;
         }
         pr_default.close(15);
      }

      protected void getByPrimaryKey0811( )
      {
         /* Using cursor T00083 */
         pr_default.execute(1, new Object[] {A45SupplierId, A7AttractionId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0811( 3) ;
            RcdFound11 = 1;
            InitializeNonKey0811( ) ;
            A48SupplierAttractionDate = T00083_A48SupplierAttractionDate[0];
            A7AttractionId = T00083_A7AttractionId[0];
            Z45SupplierId = A45SupplierId;
            Z7AttractionId = A7AttractionId;
            sMode11 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0811( ) ;
            Load0811( ) ;
            Gx_mode = sMode11;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound11 = 0;
            InitializeNonKey0811( ) ;
            sMode11 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0811( ) ;
            Gx_mode = sMode11;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0811( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0811( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00082 */
            pr_default.execute(0, new Object[] {A45SupplierId, A7AttractionId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SupplierAttraction"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z48SupplierAttractionDate ) != DateTimeUtil.ResetTime ( T00082_A48SupplierAttractionDate[0] ) ) )
            {
               if ( DateTimeUtil.ResetTime ( Z48SupplierAttractionDate ) != DateTimeUtil.ResetTime ( T00082_A48SupplierAttractionDate[0] ) )
               {
                  GXUtil.WriteLog("supplier:[seudo value changed for attri]"+"SupplierAttractionDate");
                  GXUtil.WriteLogRaw("Old: ",Z48SupplierAttractionDate);
                  GXUtil.WriteLogRaw("Current: ",T00082_A48SupplierAttractionDate[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SupplierAttraction"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0811( )
      {
         BeforeValidate0811( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0811( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0811( 0) ;
            CheckOptimisticConcurrency0811( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0811( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0811( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000818 */
                     pr_default.execute(16, new Object[] {A45SupplierId, A48SupplierAttractionDate, A7AttractionId});
                     pr_default.close(16);
                     pr_default.SmartCacheProvider.SetUpdated("SupplierAttraction");
                     if ( (pr_default.getStatus(16) == 1) )
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
               Load0811( ) ;
            }
            EndLevel0811( ) ;
         }
         CloseExtendedTableCursors0811( ) ;
      }

      protected void Update0811( )
      {
         BeforeValidate0811( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0811( ) ;
         }
         if ( ( nIsMod_11 != 0 ) || ( nIsDirty_11 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency0811( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm0811( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate0811( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000819 */
                        pr_default.execute(17, new Object[] {A48SupplierAttractionDate, A45SupplierId, A7AttractionId});
                        pr_default.close(17);
                        pr_default.SmartCacheProvider.SetUpdated("SupplierAttraction");
                        if ( (pr_default.getStatus(17) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SupplierAttraction"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate0811( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey0811( ) ;
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
               EndLevel0811( ) ;
            }
         }
         CloseExtendedTableCursors0811( ) ;
      }

      protected void DeferredUpdate0811( )
      {
      }

      protected void Delete0811( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0811( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0811( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0811( ) ;
            AfterConfirm0811( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0811( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000820 */
                  pr_default.execute(18, new Object[] {A45SupplierId, A7AttractionId});
                  pr_default.close(18);
                  pr_default.SmartCacheProvider.SetUpdated("SupplierAttraction");
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
         sMode11 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0811( ) ;
         Gx_mode = sMode11;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0811( )
      {
         standaloneModal0811( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000821 */
            pr_default.execute(19, new Object[] {A7AttractionId});
            A8AttractionName = T000821_A8AttractionName[0];
            A40000AttractionPhoto_GXI = T000821_A40000AttractionPhoto_GXI[0];
            AssignProp("", false, edtAttractionPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A13AttractionPhoto)) ? A40000AttractionPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A13AttractionPhoto))), !bGXsfl_53_Refreshing);
            AssignProp("", false, edtAttractionPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A13AttractionPhoto), true);
            A13AttractionPhoto = T000821_A13AttractionPhoto[0];
            AssignProp("", false, edtAttractionPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A13AttractionPhoto)) ? A40000AttractionPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A13AttractionPhoto))), !bGXsfl_53_Refreshing);
            AssignProp("", false, edtAttractionPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A13AttractionPhoto), true);
            pr_default.close(19);
         }
      }

      protected void EndLevel0811( )
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

      public void ScanStart0811( )
      {
         /* Scan By routine */
         /* Using cursor T000822 */
         pr_default.execute(20, new Object[] {A45SupplierId});
         RcdFound11 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound11 = 1;
            A7AttractionId = T000822_A7AttractionId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0811( )
      {
         /* Scan next routine */
         pr_default.readNext(20);
         RcdFound11 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound11 = 1;
            A7AttractionId = T000822_A7AttractionId[0];
         }
      }

      protected void ScanEnd0811( )
      {
         pr_default.close(20);
      }

      protected void AfterConfirm0811( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0811( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0811( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0811( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0811( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0811( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0811( )
      {
         edtAttractionId_Enabled = 0;
         AssignProp("", false, edtAttractionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAttractionId_Enabled), 5, 0), !bGXsfl_53_Refreshing);
         edtAttractionName_Enabled = 0;
         AssignProp("", false, edtAttractionName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAttractionName_Enabled), 5, 0), !bGXsfl_53_Refreshing);
         edtAttractionPhoto_Enabled = 0;
         AssignProp("", false, edtAttractionPhoto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAttractionPhoto_Enabled), 5, 0), !bGXsfl_53_Refreshing);
         edtSupplierAttractionDate_Enabled = 0;
         AssignProp("", false, edtSupplierAttractionDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierAttractionDate_Enabled), 5, 0), !bGXsfl_53_Refreshing);
      }

      protected void send_integrity_lvl_hashes0811( )
      {
      }

      protected void send_integrity_lvl_hashes0810( )
      {
      }

      protected void SubsflControlProps_5311( )
      {
         edtAttractionId_Internalname = "ATTRACTIONID_"+sGXsfl_53_idx;
         imgprompt_7_Internalname = "PROMPT_7_"+sGXsfl_53_idx;
         edtAttractionName_Internalname = "ATTRACTIONNAME_"+sGXsfl_53_idx;
         edtAttractionPhoto_Internalname = "ATTRACTIONPHOTO_"+sGXsfl_53_idx;
         edtSupplierAttractionDate_Internalname = "SUPPLIERATTRACTIONDATE_"+sGXsfl_53_idx;
      }

      protected void SubsflControlProps_fel_5311( )
      {
         edtAttractionId_Internalname = "ATTRACTIONID_"+sGXsfl_53_fel_idx;
         imgprompt_7_Internalname = "PROMPT_7_"+sGXsfl_53_fel_idx;
         edtAttractionName_Internalname = "ATTRACTIONNAME_"+sGXsfl_53_fel_idx;
         edtAttractionPhoto_Internalname = "ATTRACTIONPHOTO_"+sGXsfl_53_fel_idx;
         edtSupplierAttractionDate_Internalname = "SUPPLIERATTRACTIONDATE_"+sGXsfl_53_fel_idx;
      }

      protected void AddRow0811( )
      {
         nGXsfl_53_idx = (int)(nGXsfl_53_idx+1);
         sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
         SubsflControlProps_5311( ) ;
         SendRow0811( ) ;
      }

      protected void SendRow0811( )
      {
         Gridsupplier_attractionRow = GXWebRow.GetNew(context);
         if ( subGridsupplier_attraction_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridsupplier_attraction_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridsupplier_attraction_Class, "") != 0 )
            {
               subGridsupplier_attraction_Linesclass = subGridsupplier_attraction_Class+"Odd";
            }
         }
         else if ( subGridsupplier_attraction_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridsupplier_attraction_Backstyle = 0;
            subGridsupplier_attraction_Backcolor = subGridsupplier_attraction_Allbackcolor;
            if ( StringUtil.StrCmp(subGridsupplier_attraction_Class, "") != 0 )
            {
               subGridsupplier_attraction_Linesclass = subGridsupplier_attraction_Class+"Uniform";
            }
         }
         else if ( subGridsupplier_attraction_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridsupplier_attraction_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridsupplier_attraction_Class, "") != 0 )
            {
               subGridsupplier_attraction_Linesclass = subGridsupplier_attraction_Class+"Odd";
            }
            subGridsupplier_attraction_Backcolor = (int)(0x0);
         }
         else if ( subGridsupplier_attraction_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridsupplier_attraction_Backstyle = 1;
            if ( ((int)((nGXsfl_53_idx) % (2))) == 0 )
            {
               subGridsupplier_attraction_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridsupplier_attraction_Class, "") != 0 )
               {
                  subGridsupplier_attraction_Linesclass = subGridsupplier_attraction_Class+"Even";
               }
            }
            else
            {
               subGridsupplier_attraction_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridsupplier_attraction_Class, "") != 0 )
               {
                  subGridsupplier_attraction_Linesclass = subGridsupplier_attraction_Class+"Odd";
               }
            }
         }
         imgprompt_7_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0)||(StringUtil.StrCmp(Gx_mode, "UPD")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0020.aspx"+"',["+"{Ctrl:gx.dom.el('"+"ATTRACTIONID_"+sGXsfl_53_idx+"'), id:'"+"ATTRACTIONID_"+sGXsfl_53_idx+"'"+",IOType:'out'}"+"],"+"gx.dom.form()."+"nIsMod_11_"+sGXsfl_53_idx+","+"'', false"+","+"false"+");");
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_11_" + sGXsfl_53_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 54,'',false,'" + sGXsfl_53_idx + "',53)\"";
         ROClassString = "Attribute";
         Gridsupplier_attractionRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAttractionId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A7AttractionId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A7AttractionId), "ZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,54);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAttractionId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtAttractionId_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)53,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_7_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_7_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         Gridsupplier_attractionRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)imgprompt_7_Internalname,(string)sImgUrl,(string)imgprompt_7_Link,(string)"",(string)"",context.GetTheme( ),(int)imgprompt_7_Visible,(short)1,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_11_" + sGXsfl_53_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 55,'',false,'" + sGXsfl_53_idx + "',53)\"";
         ROClassString = "Attribute";
         Gridsupplier_attractionRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAttractionName_Internalname,StringUtil.RTrim( A8AttractionName),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,55);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAttractionName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtAttractionName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)50,(short)0,(short)0,(short)53,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Static Bitmap Variable */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_11_" + sGXsfl_53_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_53_idx + "',53)\"";
         ClassString = "ImageAttribute";
         StyleString = "";
         A13AttractionPhoto_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A13AttractionPhoto))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000AttractionPhoto_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A13AttractionPhoto)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A13AttractionPhoto)) ? A40000AttractionPhoto_GXI : context.PathToRelativeUrl( A13AttractionPhoto));
         Gridsupplier_attractionRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtAttractionPhoto_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(int)edtAttractionPhoto_Enabled,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"",(string)"",(string)"",(string)"",(short)0,(bool)A13AttractionPhoto_IsBlob,(bool)true,context.GetImageSrcSet( sImgUrl)});
         AssignProp("", false, edtAttractionPhoto_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A13AttractionPhoto)) ? A40000AttractionPhoto_GXI : context.PathToRelativeUrl( A13AttractionPhoto)), !bGXsfl_53_Refreshing);
         AssignProp("", false, edtAttractionPhoto_Internalname, "IsBlob", StringUtil.BoolToStr( A13AttractionPhoto_IsBlob), !bGXsfl_53_Refreshing);
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_11_" + sGXsfl_53_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 57,'',false,'" + sGXsfl_53_idx + "',53)\"";
         ROClassString = "Attribute";
         Gridsupplier_attractionRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierAttractionDate_Internalname,context.localUtil.Format(A48SupplierAttractionDate, "99/99/99"),context.localUtil.Format( A48SupplierAttractionDate, "99/99/99"),TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,57);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplierAttractionDate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtSupplierAttractionDate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)53,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         ajax_sending_grid_row(Gridsupplier_attractionRow);
         send_integrity_lvl_hashes0811( ) ;
         GXCCtl = "Z7AttractionId_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z7AttractionId), 4, 0, ".", "")));
         GXCCtl = "Z48SupplierAttractionDate_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, context.localUtil.DToC( Z48SupplierAttractionDate, 0, "/"));
         GXCCtl = "nRcdDeleted_11_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_11), 4, 0, ".", "")));
         GXCCtl = "nRcdExists_11_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_11), 4, 0, ".", "")));
         GXCCtl = "nIsMod_11_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_11), 4, 0, ".", "")));
         GXCCtl = "ATTRACTIONPHOTO_" + sGXsfl_53_idx;
         GXCCtlgxBlob = GXCCtl + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A13AttractionPhoto);
         GxWebStd.gx_hidden_field( context, "ATTRACTIONID_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAttractionId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ATTRACTIONNAME_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAttractionName_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ATTRACTIONPHOTO_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAttractionPhoto_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "SUPPLIERATTRACTIONDATE_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplierAttractionDate_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROMPT_7_"+sGXsfl_53_idx+"Link", StringUtil.RTrim( imgprompt_7_Link));
         ajax_sending_grid_row(null);
         Gridsupplier_attractionContainer.AddRow(Gridsupplier_attractionRow);
      }

      protected void ReadRow0811( )
      {
         nGXsfl_53_idx = (int)(nGXsfl_53_idx+1);
         sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
         SubsflControlProps_5311( ) ;
         edtAttractionId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ATTRACTIONID_"+sGXsfl_53_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         edtAttractionName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ATTRACTIONNAME_"+sGXsfl_53_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         edtAttractionPhoto_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ATTRACTIONPHOTO_"+sGXsfl_53_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         edtSupplierAttractionDate_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SUPPLIERATTRACTIONDATE_"+sGXsfl_53_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         imgprompt_7_Link = cgiGet( "PROMPT_7_"+sGXsfl_53_idx+"Link");
         if ( ( ( context.localUtil.CToN( cgiGet( edtAttractionId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAttractionId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "ATTRACTIONID_" + sGXsfl_53_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtAttractionId_Internalname;
            wbErr = true;
            A7AttractionId = 0;
         }
         else
         {
            A7AttractionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtAttractionId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
         }
         A8AttractionName = cgiGet( edtAttractionName_Internalname);
         A13AttractionPhoto = cgiGet( edtAttractionPhoto_Internalname);
         if ( context.localUtil.VCDate( cgiGet( edtSupplierAttractionDate_Internalname), 1) == 0 )
         {
            GXCCtl = "SUPPLIERATTRACTIONDATE_" + sGXsfl_53_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Supplier Attraction Date"}), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtSupplierAttractionDate_Internalname;
            wbErr = true;
            A48SupplierAttractionDate = DateTime.MinValue;
         }
         else
         {
            A48SupplierAttractionDate = context.localUtil.CToD( cgiGet( edtSupplierAttractionDate_Internalname), 1);
         }
         GXCCtl = "Z7AttractionId_" + sGXsfl_53_idx;
         Z7AttractionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "Z48SupplierAttractionDate_" + sGXsfl_53_idx;
         Z48SupplierAttractionDate = context.localUtil.CToD( cgiGet( GXCCtl), 0);
         GXCCtl = "nRcdDeleted_11_" + sGXsfl_53_idx;
         nRcdDeleted_11 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_11_" + sGXsfl_53_idx;
         nRcdExists_11 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_11_" + sGXsfl_53_idx;
         nIsMod_11 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         getMultimediaValue(edtAttractionPhoto_Internalname, ref  A13AttractionPhoto, ref  A40000AttractionPhoto_GXI);
      }

      protected void assign_properties_default( )
      {
         defedtAttractionId_Enabled = edtAttractionId_Enabled;
      }

      protected void ConfirmValues080( )
      {
         nGXsfl_53_idx = 0;
         sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
         SubsflControlProps_5311( ) ;
         while ( nGXsfl_53_idx < nRC_GXsfl_53 )
         {
            nGXsfl_53_idx = (int)(nGXsfl_53_idx+1);
            sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
            SubsflControlProps_5311( ) ;
            ChangePostValue( "Z7AttractionId_"+sGXsfl_53_idx, cgiGet( "ZT_"+"Z7AttractionId_"+sGXsfl_53_idx)) ;
            DeletePostValue( "ZT_"+"Z7AttractionId_"+sGXsfl_53_idx) ;
            ChangePostValue( "Z48SupplierAttractionDate_"+sGXsfl_53_idx, cgiGet( "ZT_"+"Z48SupplierAttractionDate_"+sGXsfl_53_idx)) ;
            DeletePostValue( "ZT_"+"Z48SupplierAttractionDate_"+sGXsfl_53_idx) ;
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
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 239440), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 239440), false, true);
         context.AddJavascriptSource("calendar-en.js", "?"+context.GetBuildNumber( 239440), false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("supplier.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z45SupplierId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z45SupplierId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z46SupplierName", StringUtil.RTrim( Z46SupplierName));
         GxWebStd.gx_hidden_field( context, "Z47SupplierAddress", Z47SupplierAddress);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_53", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_53_idx), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ATTRACTIONPHOTO_GXI", A40000AttractionPhoto_GXI);
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
         return formatLink("supplier.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Supplier" ;
      }

      public override string GetPgmdesc( )
      {
         return "Supplier" ;
      }

      protected void InitializeNonKey0810( )
      {
         A46SupplierName = "";
         AssignAttri("", false, "A46SupplierName", A46SupplierName);
         A47SupplierAddress = "";
         AssignAttri("", false, "A47SupplierAddress", A47SupplierAddress);
         Z46SupplierName = "";
         Z47SupplierAddress = "";
      }

      protected void InitAll0810( )
      {
         A45SupplierId = 0;
         AssignAttri("", false, "A45SupplierId", StringUtil.LTrimStr( (decimal)(A45SupplierId), 4, 0));
         InitializeNonKey0810( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey0811( )
      {
         A8AttractionName = "";
         A13AttractionPhoto = "";
         AssignProp("", false, edtAttractionPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A13AttractionPhoto)) ? A40000AttractionPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A13AttractionPhoto))), !bGXsfl_53_Refreshing);
         AssignProp("", false, edtAttractionPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A13AttractionPhoto), true);
         A40000AttractionPhoto_GXI = "";
         AssignProp("", false, edtAttractionPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A13AttractionPhoto)) ? A40000AttractionPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A13AttractionPhoto))), !bGXsfl_53_Refreshing);
         AssignProp("", false, edtAttractionPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A13AttractionPhoto), true);
         A48SupplierAttractionDate = DateTime.MinValue;
         Z48SupplierAttractionDate = DateTime.MinValue;
      }

      protected void InitAll0811( )
      {
         A7AttractionId = 0;
         InitializeNonKey0811( ) ;
      }

      protected void StandaloneModalInsert0811( )
      {
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20262192051667", true, true);
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
         context.AddJavascriptSource("supplier.js", "?20262192051668", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties11( )
      {
         edtAttractionId_Enabled = defedtAttractionId_Enabled;
         AssignProp("", false, edtAttractionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAttractionId_Enabled), 5, 0), !bGXsfl_53_Refreshing);
      }

      protected void StartGridControl53( )
      {
         Gridsupplier_attractionContainer.AddObjectProperty("GridName", "Gridsupplier_attraction");
         Gridsupplier_attractionContainer.AddObjectProperty("Header", subGridsupplier_attraction_Header);
         Gridsupplier_attractionContainer.AddObjectProperty("Class", "Grid");
         Gridsupplier_attractionContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridsupplier_attractionContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridsupplier_attractionContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsupplier_attraction_Backcolorstyle), 1, 0, ".", "")));
         Gridsupplier_attractionContainer.AddObjectProperty("CmpContext", "");
         Gridsupplier_attractionContainer.AddObjectProperty("InMasterPage", "false");
         Gridsupplier_attractionColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridsupplier_attractionColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A7AttractionId), 4, 0, ".", ""))));
         Gridsupplier_attractionColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAttractionId_Enabled), 5, 0, ".", "")));
         Gridsupplier_attractionContainer.AddColumnProperties(Gridsupplier_attractionColumn);
         Gridsupplier_attractionColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridsupplier_attractionContainer.AddColumnProperties(Gridsupplier_attractionColumn);
         Gridsupplier_attractionColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridsupplier_attractionColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A8AttractionName)));
         Gridsupplier_attractionColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAttractionName_Enabled), 5, 0, ".", "")));
         Gridsupplier_attractionContainer.AddColumnProperties(Gridsupplier_attractionColumn);
         Gridsupplier_attractionColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridsupplier_attractionColumn.AddObjectProperty("Value", context.convertURL( A13AttractionPhoto));
         Gridsupplier_attractionColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAttractionPhoto_Enabled), 5, 0, ".", "")));
         Gridsupplier_attractionContainer.AddColumnProperties(Gridsupplier_attractionColumn);
         Gridsupplier_attractionColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridsupplier_attractionColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A48SupplierAttractionDate, "99/99/99")));
         Gridsupplier_attractionColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSupplierAttractionDate_Enabled), 5, 0, ".", "")));
         Gridsupplier_attractionContainer.AddColumnProperties(Gridsupplier_attractionColumn);
         Gridsupplier_attractionContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsupplier_attraction_Selectedindex), 4, 0, ".", "")));
         Gridsupplier_attractionContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsupplier_attraction_Allowselection), 1, 0, ".", "")));
         Gridsupplier_attractionContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsupplier_attraction_Selectioncolor), 9, 0, ".", "")));
         Gridsupplier_attractionContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsupplier_attraction_Allowhovering), 1, 0, ".", "")));
         Gridsupplier_attractionContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsupplier_attraction_Hoveringcolor), 9, 0, ".", "")));
         Gridsupplier_attractionContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsupplier_attraction_Allowcollapsing), 1, 0, ".", "")));
         Gridsupplier_attractionContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsupplier_attraction_Collapsed), 1, 0, ".", "")));
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
         edtSupplierId_Internalname = "SUPPLIERID";
         edtSupplierName_Internalname = "SUPPLIERNAME";
         edtSupplierAddress_Internalname = "SUPPLIERADDRESS";
         lblTitleattraction_Internalname = "TITLEATTRACTION";
         edtAttractionId_Internalname = "ATTRACTIONID";
         edtAttractionName_Internalname = "ATTRACTIONNAME";
         edtAttractionPhoto_Internalname = "ATTRACTIONPHOTO";
         edtSupplierAttractionDate_Internalname = "SUPPLIERATTRACTIONDATE";
         divAttractiontable_Internalname = "ATTRACTIONTABLE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_7_Internalname = "PROMPT_7";
         subGridsupplier_attraction_Internalname = "GRIDSUPPLIER_ATTRACTION";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("TravelAgency", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridsupplier_attraction_Allowcollapsing = 0;
         subGridsupplier_attraction_Allowselection = 0;
         subGridsupplier_attraction_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Supplier";
         edtSupplierAttractionDate_Jsonclick = "";
         edtAttractionName_Jsonclick = "";
         imgprompt_7_Visible = 1;
         imgprompt_7_Link = "";
         imgprompt_7_Visible = 1;
         edtAttractionId_Jsonclick = "";
         subGridsupplier_attraction_Class = "Grid";
         subGridsupplier_attraction_Backcolorstyle = 0;
         edtSupplierAttractionDate_Enabled = 1;
         edtAttractionPhoto_Enabled = 0;
         edtAttractionName_Enabled = 0;
         edtAttractionId_Enabled = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtSupplierAddress_Enabled = 1;
         edtSupplierName_Jsonclick = "";
         edtSupplierName_Enabled = 1;
         edtSupplierId_Jsonclick = "";
         edtSupplierId_Enabled = 1;
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

      protected void gxnrGridsupplier_attraction_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_5311( ) ;
         while ( nGXsfl_53_idx <= nRC_GXsfl_53 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0811( ) ;
            standaloneModal0811( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0811( ) ;
            nGXsfl_53_idx = (int)(nGXsfl_53_idx+1);
            sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
            SubsflControlProps_5311( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridsupplier_attractionContainer)) ;
         /* End function gxnrGridsupplier_attraction_newrow */
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
         GX_FocusControl = edtSupplierName_Internalname;
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

      public void Valid_Supplierid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A46SupplierName", StringUtil.RTrim( A46SupplierName));
         AssignAttri("", false, "A47SupplierAddress", A47SupplierAddress);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z45SupplierId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z45SupplierId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z46SupplierName", StringUtil.RTrim( Z46SupplierName));
         GxWebStd.gx_hidden_field( context, "Z47SupplierAddress", Z47SupplierAddress);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Attractionid( )
      {
         /* Using cursor T000821 */
         pr_default.execute(19, new Object[] {A7AttractionId});
         if ( (pr_default.getStatus(19) == 101) )
         {
            GX_msglist.addItem("No matching 'Attractions'.", "ForeignKeyNotFound", 1, "ATTRACTIONID");
            AnyError = 1;
            GX_FocusControl = edtAttractionId_Internalname;
         }
         A8AttractionName = T000821_A8AttractionName[0];
         A40000AttractionPhoto_GXI = T000821_A40000AttractionPhoto_GXI[0];
         A13AttractionPhoto = T000821_A13AttractionPhoto[0];
         pr_default.close(19);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A8AttractionName", StringUtil.RTrim( A8AttractionName));
         AssignAttri("", false, "A13AttractionPhoto", context.PathToRelativeUrl( A13AttractionPhoto));
         GXCCtl = "ATTRACTIONPHOTO_" + sGXsfl_53_idx;
         AssignAttri("", false, "GXCCtl", GXCCtl);
         GXCCtlgxBlob = GXCCtl + "_gxBlob";
         AssignAttri("", false, "GXCCtlgxBlob", GXCCtlgxBlob);
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, context.PathToRelativeUrl( A13AttractionPhoto));
         AssignAttri("", false, "A40000AttractionPhoto_GXI", A40000AttractionPhoto_GXI);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[]}""");
         setEventMetadata("VALID_SUPPLIERID","""{"handler":"Valid_Supplierid","iparms":[{"av":"A45SupplierId","fld":"SUPPLIERID","pic":"ZZZ9"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"}]""");
         setEventMetadata("VALID_SUPPLIERID",""","oparms":[{"av":"A46SupplierName","fld":"SUPPLIERNAME"},{"av":"A47SupplierAddress","fld":"SUPPLIERADDRESS"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"Z45SupplierId"},{"av":"Z46SupplierName"},{"av":"Z47SupplierAddress"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"}]}""");
         setEventMetadata("VALID_ATTRACTIONID","""{"handler":"Valid_Attractionid","iparms":[{"av":"A7AttractionId","fld":"ATTRACTIONID","pic":"ZZZ9"},{"av":"A8AttractionName","fld":"ATTRACTIONNAME"},{"av":"A13AttractionPhoto","fld":"ATTRACTIONPHOTO"},{"av":"A40000AttractionPhoto_GXI","fld":"ATTRACTIONPHOTO_GXI"}]""");
         setEventMetadata("VALID_ATTRACTIONID",""","oparms":[{"av":"A8AttractionName","fld":"ATTRACTIONNAME"},{"av":"A13AttractionPhoto","fld":"ATTRACTIONPHOTO"},{"av":"A40000AttractionPhoto_GXI","fld":"ATTRACTIONPHOTO_GXI"}]}""");
         setEventMetadata("VALID_SUPPLIERATTRACTIONDATE","""{"handler":"Valid_Supplierattractiondate","iparms":[]}""");
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
         pr_default.close(19);
         pr_default.close(4);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z46SupplierName = "";
         Z47SupplierAddress = "";
         Z48SupplierAttractionDate = DateTime.MinValue;
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
         A46SupplierName = "";
         A47SupplierAddress = "";
         lblTitleattraction_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gridsupplier_attractionContainer = new GXWebGrid( context);
         sMode11 = "";
         sStyleString = "";
         A40000AttractionPhoto_GXI = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         A8AttractionName = "";
         A13AttractionPhoto = "";
         A48SupplierAttractionDate = DateTime.MinValue;
         T00087_A45SupplierId = new short[1] ;
         T00087_A46SupplierName = new string[] {""} ;
         T00087_A47SupplierAddress = new string[] {""} ;
         T00088_A45SupplierId = new short[1] ;
         T00086_A45SupplierId = new short[1] ;
         T00086_A46SupplierName = new string[] {""} ;
         T00086_A47SupplierAddress = new string[] {""} ;
         sMode10 = "";
         T00089_A45SupplierId = new short[1] ;
         T000810_A45SupplierId = new short[1] ;
         T00085_A45SupplierId = new short[1] ;
         T00085_A46SupplierName = new string[] {""} ;
         T00085_A47SupplierAddress = new string[] {""} ;
         T000811_A45SupplierId = new short[1] ;
         T000814_A45SupplierId = new short[1] ;
         Z8AttractionName = "";
         Z13AttractionPhoto = "";
         Z40000AttractionPhoto_GXI = "";
         T000815_A45SupplierId = new short[1] ;
         T000815_A8AttractionName = new string[] {""} ;
         T000815_A40000AttractionPhoto_GXI = new string[] {""} ;
         T000815_A48SupplierAttractionDate = new DateTime[] {DateTime.MinValue} ;
         T000815_A7AttractionId = new short[1] ;
         T000815_A13AttractionPhoto = new string[] {""} ;
         T00084_A8AttractionName = new string[] {""} ;
         T00084_A40000AttractionPhoto_GXI = new string[] {""} ;
         T00084_A13AttractionPhoto = new string[] {""} ;
         T000816_A8AttractionName = new string[] {""} ;
         T000816_A40000AttractionPhoto_GXI = new string[] {""} ;
         T000816_A13AttractionPhoto = new string[] {""} ;
         T000817_A45SupplierId = new short[1] ;
         T000817_A7AttractionId = new short[1] ;
         T00083_A45SupplierId = new short[1] ;
         T00083_A48SupplierAttractionDate = new DateTime[] {DateTime.MinValue} ;
         T00083_A7AttractionId = new short[1] ;
         T00082_A45SupplierId = new short[1] ;
         T00082_A48SupplierAttractionDate = new DateTime[] {DateTime.MinValue} ;
         T00082_A7AttractionId = new short[1] ;
         T000821_A8AttractionName = new string[] {""} ;
         T000821_A40000AttractionPhoto_GXI = new string[] {""} ;
         T000821_A13AttractionPhoto = new string[] {""} ;
         T000822_A45SupplierId = new short[1] ;
         T000822_A7AttractionId = new short[1] ;
         Gridsupplier_attractionRow = new GXWebRow();
         subGridsupplier_attraction_Linesclass = "";
         ROClassString = "";
         imgprompt_7_gximage = "";
         sImgUrl = "";
         GXCCtlgxBlob = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         Gridsupplier_attractionColumn = new GXWebColumn();
         ZZ46SupplierName = "";
         ZZ47SupplierAddress = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.supplier__default(),
            new Object[][] {
                new Object[] {
               T00082_A45SupplierId, T00082_A48SupplierAttractionDate, T00082_A7AttractionId
               }
               , new Object[] {
               T00083_A45SupplierId, T00083_A48SupplierAttractionDate, T00083_A7AttractionId
               }
               , new Object[] {
               T00084_A8AttractionName, T00084_A40000AttractionPhoto_GXI, T00084_A13AttractionPhoto
               }
               , new Object[] {
               T00085_A45SupplierId, T00085_A46SupplierName, T00085_A47SupplierAddress
               }
               , new Object[] {
               T00086_A45SupplierId, T00086_A46SupplierName, T00086_A47SupplierAddress
               }
               , new Object[] {
               T00087_A45SupplierId, T00087_A46SupplierName, T00087_A47SupplierAddress
               }
               , new Object[] {
               T00088_A45SupplierId
               }
               , new Object[] {
               T00089_A45SupplierId
               }
               , new Object[] {
               T000810_A45SupplierId
               }
               , new Object[] {
               T000811_A45SupplierId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000814_A45SupplierId
               }
               , new Object[] {
               T000815_A45SupplierId, T000815_A8AttractionName, T000815_A40000AttractionPhoto_GXI, T000815_A48SupplierAttractionDate, T000815_A7AttractionId, T000815_A13AttractionPhoto
               }
               , new Object[] {
               T000816_A8AttractionName, T000816_A40000AttractionPhoto_GXI, T000816_A13AttractionPhoto
               }
               , new Object[] {
               T000817_A45SupplierId, T000817_A7AttractionId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000821_A8AttractionName, T000821_A40000AttractionPhoto_GXI, T000821_A13AttractionPhoto
               }
               , new Object[] {
               T000822_A45SupplierId, T000822_A7AttractionId
               }
            }
         );
      }

      private short nIsMod_11 ;
      private short Z45SupplierId ;
      private short Z7AttractionId ;
      private short nRcdDeleted_11 ;
      private short nRcdExists_11 ;
      private short GxWebError ;
      private short A7AttractionId ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A45SupplierId ;
      private short nBlankRcdCount11 ;
      private short RcdFound11 ;
      private short nBlankRcdUsr11 ;
      private short RcdFound10 ;
      private short Gx_BScreen ;
      private short nIsDirty_11 ;
      private short subGridsupplier_attraction_Backcolorstyle ;
      private short subGridsupplier_attraction_Backstyle ;
      private short gxajaxcallmode ;
      private short subGridsupplier_attraction_Allowselection ;
      private short subGridsupplier_attraction_Allowhovering ;
      private short subGridsupplier_attraction_Allowcollapsing ;
      private short subGridsupplier_attraction_Collapsed ;
      private short ZZ45SupplierId ;
      private int nRC_GXsfl_53 ;
      private int nGXsfl_53_idx=1 ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtSupplierId_Enabled ;
      private int edtSupplierName_Enabled ;
      private int edtSupplierAddress_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int edtAttractionId_Enabled ;
      private int edtAttractionName_Enabled ;
      private int edtAttractionPhoto_Enabled ;
      private int edtSupplierAttractionDate_Enabled ;
      private int fRowAdded ;
      private int subGridsupplier_attraction_Backcolor ;
      private int subGridsupplier_attraction_Allbackcolor ;
      private int imgprompt_7_Visible ;
      private int defedtAttractionId_Enabled ;
      private int idxLst ;
      private int subGridsupplier_attraction_Selectedindex ;
      private int subGridsupplier_attraction_Selectioncolor ;
      private int subGridsupplier_attraction_Hoveringcolor ;
      private long GRIDSUPPLIER_ATTRACTION_nFirstRecordOnPage ;
      private string sPrefix ;
      private string sGXsfl_53_idx="0001" ;
      private string Z46SupplierName ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtSupplierId_Internalname ;
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
      private string edtSupplierId_Jsonclick ;
      private string edtSupplierName_Internalname ;
      private string A46SupplierName ;
      private string edtSupplierName_Jsonclick ;
      private string edtSupplierAddress_Internalname ;
      private string divAttractiontable_Internalname ;
      private string lblTitleattraction_Internalname ;
      private string lblTitleattraction_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string sMode11 ;
      private string edtAttractionId_Internalname ;
      private string edtAttractionName_Internalname ;
      private string edtAttractionPhoto_Internalname ;
      private string edtSupplierAttractionDate_Internalname ;
      private string imgprompt_7_Link ;
      private string sStyleString ;
      private string subGridsupplier_attraction_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string A8AttractionName ;
      private string sMode10 ;
      private string Z8AttractionName ;
      private string imgprompt_7_Internalname ;
      private string sGXsfl_53_fel_idx="0001" ;
      private string subGridsupplier_attraction_Class ;
      private string subGridsupplier_attraction_Linesclass ;
      private string ROClassString ;
      private string edtAttractionId_Jsonclick ;
      private string imgprompt_7_gximage ;
      private string sImgUrl ;
      private string edtAttractionName_Jsonclick ;
      private string edtSupplierAttractionDate_Jsonclick ;
      private string GXCCtlgxBlob ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridsupplier_attraction_Header ;
      private string ZZ46SupplierName ;
      private DateTime Z48SupplierAttractionDate ;
      private DateTime A48SupplierAttractionDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool bGXsfl_53_Refreshing=false ;
      private bool A13AttractionPhoto_IsBlob ;
      private string Z47SupplierAddress ;
      private string A47SupplierAddress ;
      private string A40000AttractionPhoto_GXI ;
      private string Z40000AttractionPhoto_GXI ;
      private string ZZ47SupplierAddress ;
      private string A13AttractionPhoto ;
      private string Z13AttractionPhoto ;
      private GXWebGrid Gridsupplier_attractionContainer ;
      private GXWebRow Gridsupplier_attractionRow ;
      private GXWebColumn Gridsupplier_attractionColumn ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] T00087_A45SupplierId ;
      private string[] T00087_A46SupplierName ;
      private string[] T00087_A47SupplierAddress ;
      private short[] T00088_A45SupplierId ;
      private short[] T00086_A45SupplierId ;
      private string[] T00086_A46SupplierName ;
      private string[] T00086_A47SupplierAddress ;
      private short[] T00089_A45SupplierId ;
      private short[] T000810_A45SupplierId ;
      private short[] T00085_A45SupplierId ;
      private string[] T00085_A46SupplierName ;
      private string[] T00085_A47SupplierAddress ;
      private short[] T000811_A45SupplierId ;
      private short[] T000814_A45SupplierId ;
      private short[] T000815_A45SupplierId ;
      private string[] T000815_A8AttractionName ;
      private string[] T000815_A40000AttractionPhoto_GXI ;
      private DateTime[] T000815_A48SupplierAttractionDate ;
      private short[] T000815_A7AttractionId ;
      private string[] T000815_A13AttractionPhoto ;
      private string[] T00084_A8AttractionName ;
      private string[] T00084_A40000AttractionPhoto_GXI ;
      private string[] T00084_A13AttractionPhoto ;
      private string[] T000816_A8AttractionName ;
      private string[] T000816_A40000AttractionPhoto_GXI ;
      private string[] T000816_A13AttractionPhoto ;
      private short[] T000817_A45SupplierId ;
      private short[] T000817_A7AttractionId ;
      private short[] T00083_A45SupplierId ;
      private DateTime[] T00083_A48SupplierAttractionDate ;
      private short[] T00083_A7AttractionId ;
      private short[] T00082_A45SupplierId ;
      private DateTime[] T00082_A48SupplierAttractionDate ;
      private short[] T00082_A7AttractionId ;
      private string[] T000821_A8AttractionName ;
      private string[] T000821_A40000AttractionPhoto_GXI ;
      private string[] T000821_A13AttractionPhoto ;
      private short[] T000822_A45SupplierId ;
      private short[] T000822_A7AttractionId ;
   }

   public class supplier__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[10])
         ,new UpdateCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new UpdateCursor(def[16])
         ,new UpdateCursor(def[17])
         ,new UpdateCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00082;
          prmT00082 = new Object[] {
          new ParDef("@SupplierId",GXType.Int16,4,0) ,
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          Object[] prmT00083;
          prmT00083 = new Object[] {
          new ParDef("@SupplierId",GXType.Int16,4,0) ,
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          Object[] prmT00084;
          prmT00084 = new Object[] {
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          Object[] prmT00085;
          prmT00085 = new Object[] {
          new ParDef("@SupplierId",GXType.Int16,4,0)
          };
          Object[] prmT00086;
          prmT00086 = new Object[] {
          new ParDef("@SupplierId",GXType.Int16,4,0)
          };
          Object[] prmT00087;
          prmT00087 = new Object[] {
          new ParDef("@SupplierId",GXType.Int16,4,0)
          };
          Object[] prmT00088;
          prmT00088 = new Object[] {
          new ParDef("@SupplierId",GXType.Int16,4,0)
          };
          Object[] prmT00089;
          prmT00089 = new Object[] {
          new ParDef("@SupplierId",GXType.Int16,4,0)
          };
          Object[] prmT000810;
          prmT000810 = new Object[] {
          new ParDef("@SupplierId",GXType.Int16,4,0)
          };
          Object[] prmT000811;
          prmT000811 = new Object[] {
          new ParDef("@SupplierName",GXType.NChar,50,0) ,
          new ParDef("@SupplierAddress",GXType.NVarChar,1024,0)
          };
          Object[] prmT000812;
          prmT000812 = new Object[] {
          new ParDef("@SupplierName",GXType.NChar,50,0) ,
          new ParDef("@SupplierAddress",GXType.NVarChar,1024,0) ,
          new ParDef("@SupplierId",GXType.Int16,4,0)
          };
          Object[] prmT000813;
          prmT000813 = new Object[] {
          new ParDef("@SupplierId",GXType.Int16,4,0)
          };
          Object[] prmT000814;
          prmT000814 = new Object[] {
          };
          Object[] prmT000815;
          prmT000815 = new Object[] {
          new ParDef("@SupplierId",GXType.Int16,4,0) ,
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          Object[] prmT000816;
          prmT000816 = new Object[] {
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          Object[] prmT000817;
          prmT000817 = new Object[] {
          new ParDef("@SupplierId",GXType.Int16,4,0) ,
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          Object[] prmT000818;
          prmT000818 = new Object[] {
          new ParDef("@SupplierId",GXType.Int16,4,0) ,
          new ParDef("@SupplierAttractionDate",GXType.Date,8,0) ,
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          Object[] prmT000819;
          prmT000819 = new Object[] {
          new ParDef("@SupplierAttractionDate",GXType.Date,8,0) ,
          new ParDef("@SupplierId",GXType.Int16,4,0) ,
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          Object[] prmT000820;
          prmT000820 = new Object[] {
          new ParDef("@SupplierId",GXType.Int16,4,0) ,
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          Object[] prmT000821;
          prmT000821 = new Object[] {
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          Object[] prmT000822;
          prmT000822 = new Object[] {
          new ParDef("@SupplierId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00082", "SELECT [SupplierId], [SupplierAttractionDate], [AttractionId] FROM [SupplierAttraction] WITH (UPDLOCK) WHERE [SupplierId] = @SupplierId AND [AttractionId] = @AttractionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00082,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00083", "SELECT [SupplierId], [SupplierAttractionDate], [AttractionId] FROM [SupplierAttraction] WHERE [SupplierId] = @SupplierId AND [AttractionId] = @AttractionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00083,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00084", "SELECT [AttractionName], [AttractionPhoto_GXI], [AttractionPhoto] FROM [Attractions] WHERE [AttractionId] = @AttractionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00084,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00085", "SELECT [SupplierId], [SupplierName], [SupplierAddress] FROM [Supplier] WITH (UPDLOCK) WHERE [SupplierId] = @SupplierId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00085,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00086", "SELECT [SupplierId], [SupplierName], [SupplierAddress] FROM [Supplier] WHERE [SupplierId] = @SupplierId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00086,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00087", "SELECT TM1.[SupplierId], TM1.[SupplierName], TM1.[SupplierAddress] FROM [Supplier] TM1 WHERE TM1.[SupplierId] = @SupplierId ORDER BY TM1.[SupplierId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00087,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00088", "SELECT [SupplierId] FROM [Supplier] WHERE [SupplierId] = @SupplierId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00088,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00089", "SELECT TOP 1 [SupplierId] FROM [Supplier] WHERE ( [SupplierId] > @SupplierId) ORDER BY [SupplierId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00089,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000810", "SELECT TOP 1 [SupplierId] FROM [Supplier] WHERE ( [SupplierId] < @SupplierId) ORDER BY [SupplierId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000810,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000811", "INSERT INTO [Supplier]([SupplierName], [SupplierAddress]) VALUES(@SupplierName, @SupplierAddress); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000811,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000812", "UPDATE [Supplier] SET [SupplierName]=@SupplierName, [SupplierAddress]=@SupplierAddress  WHERE [SupplierId] = @SupplierId", GxErrorMask.GX_NOMASK,prmT000812)
             ,new CursorDef("T000813", "DELETE FROM [Supplier]  WHERE [SupplierId] = @SupplierId", GxErrorMask.GX_NOMASK,prmT000813)
             ,new CursorDef("T000814", "SELECT [SupplierId] FROM [Supplier] ORDER BY [SupplierId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000814,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000815", "SELECT T1.[SupplierId], T2.[AttractionName], T2.[AttractionPhoto_GXI], T1.[SupplierAttractionDate], T1.[AttractionId], T2.[AttractionPhoto] FROM ([SupplierAttraction] T1 INNER JOIN [Attractions] T2 ON T2.[AttractionId] = T1.[AttractionId]) WHERE T1.[SupplierId] = @SupplierId and T1.[AttractionId] = @AttractionId ORDER BY T1.[SupplierId], T1.[AttractionId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000815,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000816", "SELECT [AttractionName], [AttractionPhoto_GXI], [AttractionPhoto] FROM [Attractions] WHERE [AttractionId] = @AttractionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000816,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000817", "SELECT [SupplierId], [AttractionId] FROM [SupplierAttraction] WHERE [SupplierId] = @SupplierId AND [AttractionId] = @AttractionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000817,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000818", "INSERT INTO [SupplierAttraction]([SupplierId], [SupplierAttractionDate], [AttractionId]) VALUES(@SupplierId, @SupplierAttractionDate, @AttractionId)", GxErrorMask.GX_NOMASK,prmT000818)
             ,new CursorDef("T000819", "UPDATE [SupplierAttraction] SET [SupplierAttractionDate]=@SupplierAttractionDate  WHERE [SupplierId] = @SupplierId AND [AttractionId] = @AttractionId", GxErrorMask.GX_NOMASK,prmT000819)
             ,new CursorDef("T000820", "DELETE FROM [SupplierAttraction]  WHERE [SupplierId] = @SupplierId AND [AttractionId] = @AttractionId", GxErrorMask.GX_NOMASK,prmT000820)
             ,new CursorDef("T000821", "SELECT [AttractionName], [AttractionPhoto_GXI], [AttractionPhoto] FROM [Attractions] WHERE [AttractionId] = @AttractionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000821,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000822", "SELECT [SupplierId], [AttractionId] FROM [SupplierAttraction] WHERE [SupplierId] = @SupplierId ORDER BY [SupplierId], [AttractionId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000822,11, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaFile(3, rslt.getVarchar(2));
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
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
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 13 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(3));
                return;
             case 14 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaFile(3, rslt.getVarchar(2));
                return;
             case 15 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 19 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaFile(3, rslt.getVarchar(2));
                return;
             case 20 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
       }
    }

 }

}
