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
   public class attractions : GXDataArea
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
         gxfirstwebparm = GetFirstPar( "Mode");
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_17") == 0 )
         {
            A9CountryId = (short)(Math.Round(NumberUtil.Val( GetPar( "CountryId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A9CountryId", StringUtil.LTrimStr( (decimal)(A9CountryId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_17( A9CountryId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_18") == 0 )
         {
            A9CountryId = (short)(Math.Round(NumberUtil.Val( GetPar( "CountryId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A9CountryId", StringUtil.LTrimStr( (decimal)(A9CountryId), 4, 0));
            A14CityId = (short)(Math.Round(NumberUtil.Val( GetPar( "CityId"), "."), 18, MidpointRounding.ToEven));
            n14CityId = false;
            AssignAttri("", false, "A14CityId", StringUtil.LTrimStr( (decimal)(A14CityId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_18( A9CountryId, A14CityId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_19") == 0 )
         {
            A11CategoryId = (short)(Math.Round(NumberUtil.Val( GetPar( "CategoryId"), "."), 18, MidpointRounding.ToEven));
            n11CategoryId = false;
            AssignAttri("", false, "A11CategoryId", StringUtil.LTrimStr( (decimal)(A11CategoryId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_19( A11CategoryId) ;
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
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "Mode");
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
         if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
         {
            Gx_mode = gxfirstwebparm;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
            {
               AV7AttractionId = (short)(Math.Round(NumberUtil.Val( GetPar( "AttractionId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7AttractionId", StringUtil.LTrimStr( (decimal)(AV7AttractionId), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vATTRACTIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7AttractionId), "ZZZ9"), context));
            }
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
         Form.Meta.addItem("description", "Attractions", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtAttractionName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("TravelAgency", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public attractions( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("TravelAgency", true);
      }

      public attractions( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_AttractionId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7AttractionId = aP1_AttractionId;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Attractions", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Attractions.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Attractions.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Attractions.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Attractions.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Attractions.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 5, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Attractions.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAttractionId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAttractionId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAttractionId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A7AttractionId), 4, 0, ".", "")), StringUtil.LTrim( ((edtAttractionId_Enabled!=0) ? context.localUtil.Format( (decimal)(A7AttractionId), "ZZZ9") : context.localUtil.Format( (decimal)(A7AttractionId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAttractionId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAttractionId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Attractions.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAttractionName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAttractionName_Internalname, "Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAttractionName_Internalname, StringUtil.RTrim( A8AttractionName), StringUtil.RTrim( context.localUtil.Format( A8AttractionName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAttractionName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAttractionName_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Attractions.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCountryId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCountryId_Internalname, "Country Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCountryId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A9CountryId), 4, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A9CountryId), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCountryId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCountryId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Attractions.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_9_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_9_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_9_Internalname, sImgUrl, imgprompt_9_Link, "", "", context.GetTheme( ), imgprompt_9_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Attractions.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCountryName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCountryName_Internalname, "Country Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCountryName_Internalname, StringUtil.RTrim( A10CountryName), StringUtil.RTrim( context.localUtil.Format( A10CountryName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCountryName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCountryName_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Attractions.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCategoryId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCategoryId_Internalname, "Category Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCategoryId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A11CategoryId), 4, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A11CategoryId), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCategoryId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCategoryId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Attractions.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_11_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_11_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_11_Internalname, sImgUrl, imgprompt_11_Link, "", "", context.GetTheme( ), imgprompt_11_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Attractions.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCategoryName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCategoryName_Internalname, "Category Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCategoryName_Internalname, StringUtil.RTrim( A12CategoryName), StringUtil.RTrim( context.localUtil.Format( A12CategoryName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCategoryName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCategoryName_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Attractions.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgAttractionPhoto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", "Photo", "col-sm-3 ImageAttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "ImageAttribute";
         StyleString = "";
         A13AttractionPhoto_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A13AttractionPhoto))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000AttractionPhoto_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A13AttractionPhoto)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A13AttractionPhoto)) ? A40000AttractionPhoto_GXI : context.PathToRelativeUrl( A13AttractionPhoto));
         GxWebStd.gx_bitmap( context, imgAttractionPhoto_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgAttractionPhoto_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "", "", "", 0, A13AttractionPhoto_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_Attractions.htm");
         AssignProp("", false, imgAttractionPhoto_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A13AttractionPhoto)) ? A40000AttractionPhoto_GXI : context.PathToRelativeUrl( A13AttractionPhoto)), true);
         AssignProp("", false, imgAttractionPhoto_Internalname, "IsBlob", StringUtil.BoolToStr( A13AttractionPhoto_IsBlob), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCityId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCityId_Internalname, "City Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCityId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A14CityId), 4, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A14CityId), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCityId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCityId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Attractions.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_14_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_14_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_14_Internalname, sImgUrl, imgprompt_14_Link, "", "", context.GetTheme( ), imgprompt_14_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Attractions.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCityName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCityName_Internalname, "City Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCityName_Internalname, StringUtil.RTrim( A15CityName), StringUtil.RTrim( context.localUtil.Format( A15CityName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCityName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCityName_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Attractions.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", bttBtn_enter_Caption, bttBtn_enter_Jsonclick, 5, bttBtn_enter_Tooltiptext, "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Attractions.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Attractions.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Attractions.htm");
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
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11022 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z7AttractionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z7AttractionId"), ".", ","), 18, MidpointRounding.ToEven));
               Z8AttractionName = cgiGet( "Z8AttractionName");
               Z9CountryId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z9CountryId"), ".", ","), 18, MidpointRounding.ToEven));
               Z14CityId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z14CityId"), ".", ","), 18, MidpointRounding.ToEven));
               n14CityId = ((0==A14CityId) ? true : false);
               Z11CategoryId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z11CategoryId"), ".", ","), 18, MidpointRounding.ToEven));
               n11CategoryId = ((0==A11CategoryId) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N9CountryId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N9CountryId"), ".", ","), 18, MidpointRounding.ToEven));
               N11CategoryId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N11CategoryId"), ".", ","), 18, MidpointRounding.ToEven));
               n11CategoryId = ((0==A11CategoryId) ? true : false);
               N14CityId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N14CityId"), ".", ","), 18, MidpointRounding.ToEven));
               n14CityId = ((0==A14CityId) ? true : false);
               AV7AttractionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vATTRACTIONID"), ".", ","), 18, MidpointRounding.ToEven));
               AV11Insert_CountryId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_COUNTRYID"), ".", ","), 18, MidpointRounding.ToEven));
               AV12Insert_CategoryId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_CATEGORYID"), ".", ","), 18, MidpointRounding.ToEven));
               AV13Insert_CityId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_CITYID"), ".", ","), 18, MidpointRounding.ToEven));
               A40000AttractionPhoto_GXI = cgiGet( "ATTRACTIONPHOTO_GXI");
               AV16Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A7AttractionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtAttractionId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A7AttractionId", StringUtil.LTrimStr( (decimal)(A7AttractionId), 4, 0));
               A8AttractionName = cgiGet( edtAttractionName_Internalname);
               AssignAttri("", false, "A8AttractionName", A8AttractionName);
               if ( ( ( context.localUtil.CToN( cgiGet( edtCountryId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCountryId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COUNTRYID");
                  AnyError = 1;
                  GX_FocusControl = edtCountryId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A9CountryId = 0;
                  AssignAttri("", false, "A9CountryId", StringUtil.LTrimStr( (decimal)(A9CountryId), 4, 0));
               }
               else
               {
                  A9CountryId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCountryId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A9CountryId", StringUtil.LTrimStr( (decimal)(A9CountryId), 4, 0));
               }
               A10CountryName = cgiGet( edtCountryName_Internalname);
               AssignAttri("", false, "A10CountryName", A10CountryName);
               if ( ( ( context.localUtil.CToN( cgiGet( edtCategoryId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCategoryId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CATEGORYID");
                  AnyError = 1;
                  GX_FocusControl = edtCategoryId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A11CategoryId = 0;
                  n11CategoryId = false;
                  AssignAttri("", false, "A11CategoryId", StringUtil.LTrimStr( (decimal)(A11CategoryId), 4, 0));
               }
               else
               {
                  A11CategoryId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCategoryId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                  n11CategoryId = false;
                  AssignAttri("", false, "A11CategoryId", StringUtil.LTrimStr( (decimal)(A11CategoryId), 4, 0));
               }
               n11CategoryId = ((0==A11CategoryId) ? true : false);
               A12CategoryName = cgiGet( edtCategoryName_Internalname);
               AssignAttri("", false, "A12CategoryName", A12CategoryName);
               A13AttractionPhoto = cgiGet( imgAttractionPhoto_Internalname);
               AssignAttri("", false, "A13AttractionPhoto", A13AttractionPhoto);
               if ( ( ( context.localUtil.CToN( cgiGet( edtCityId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCityId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CITYID");
                  AnyError = 1;
                  GX_FocusControl = edtCityId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A14CityId = 0;
                  n14CityId = false;
                  AssignAttri("", false, "A14CityId", StringUtil.LTrimStr( (decimal)(A14CityId), 4, 0));
               }
               else
               {
                  A14CityId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCityId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                  n14CityId = false;
                  AssignAttri("", false, "A14CityId", StringUtil.LTrimStr( (decimal)(A14CityId), 4, 0));
               }
               n14CityId = ((0==A14CityId) ? true : false);
               A15CityName = cgiGet( edtCityName_Internalname);
               AssignAttri("", false, "A15CityName", A15CityName);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgAttractionPhoto_Internalname, ref  A13AttractionPhoto, ref  A40000AttractionPhoto_GXI);
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Attractions");
               A7AttractionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtAttractionId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A7AttractionId", StringUtil.LTrimStr( (decimal)(A7AttractionId), 4, 0));
               forbiddenHiddens.Add("AttractionId", context.localUtil.Format( (decimal)(A7AttractionId), "ZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A7AttractionId != Z7AttractionId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("attractions:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A7AttractionId = (short)(Math.Round(NumberUtil.Val( GetPar( "AttractionId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A7AttractionId", StringUtil.LTrimStr( (decimal)(A7AttractionId), 4, 0));
                  getEqualNoModal( ) ;
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode2 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode2;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound2 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_020( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "ATTRACTIONID");
                        AnyError = 1;
                        GX_FocusControl = edtAttractionId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
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
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E11022 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12022 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! IsDsp( ) )
                           {
                              btn_enter( ) ;
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
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
            /* Execute user event: After Trn */
            E12022 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll022( ) ;
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
         if ( IsDsp( ) || IsDlt( ) )
         {
            bttBtn_delete_Visible = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
            if ( IsDsp( ) )
            {
               bttBtn_enter_Visible = 0;
               AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
            }
            DisableAttributes022( ) ;
         }
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

      protected void CONFIRM_020( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls022( ) ;
            }
            else
            {
               CheckExtendedTable022( ) ;
               CloseExtendedTableCursors022( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption020( )
      {
      }

      protected void E11022( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV16Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV16Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         AV11Insert_CountryId = 0;
         AssignAttri("", false, "AV11Insert_CountryId", StringUtil.LTrimStr( (decimal)(AV11Insert_CountryId), 4, 0));
         AV12Insert_CategoryId = 0;
         AssignAttri("", false, "AV12Insert_CategoryId", StringUtil.LTrimStr( (decimal)(AV12Insert_CategoryId), 4, 0));
         AV13Insert_CityId = 0;
         AssignAttri("", false, "AV13Insert_CityId", StringUtil.LTrimStr( (decimal)(AV13Insert_CityId), 4, 0));
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV16Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV17GXV1 = 1;
            AssignAttri("", false, "AV17GXV1", StringUtil.LTrimStr( (decimal)(AV17GXV1), 8, 0));
            while ( AV17GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((GeneXus.Programs.general.ui.SdtTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV17GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "CountryId") == 0 )
               {
                  AV11Insert_CountryId = (short)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11Insert_CountryId", StringUtil.LTrimStr( (decimal)(AV11Insert_CountryId), 4, 0));
               }
               else if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "CategoryId") == 0 )
               {
                  AV12Insert_CategoryId = (short)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV12Insert_CategoryId", StringUtil.LTrimStr( (decimal)(AV12Insert_CategoryId), 4, 0));
               }
               else if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "CityId") == 0 )
               {
                  AV13Insert_CityId = (short)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV13Insert_CityId", StringUtil.LTrimStr( (decimal)(AV13Insert_CityId), 4, 0));
               }
               AV17GXV1 = (int)(AV17GXV1+1);
               AssignAttri("", false, "AV17GXV1", StringUtil.LTrimStr( (decimal)(AV17GXV1), 8, 0));
            }
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            bttBtn_enter_Caption = "Delete";
            AssignProp("", false, bttBtn_enter_Internalname, "Caption", bttBtn_enter_Caption, true);
            bttBtn_enter_Tooltiptext = "Delete";
            AssignProp("", false, bttBtn_enter_Internalname, "Tooltiptext", bttBtn_enter_Tooltiptext, true);
         }
      }

      protected void E12022( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwattractions.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         pr_default.close(1);
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
         returnInSub = true;
         if (true) return;
      }

      protected void ZM022( short GX_JID )
      {
         if ( ( GX_JID == 15 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z8AttractionName = T00023_A8AttractionName[0];
               Z9CountryId = T00023_A9CountryId[0];
               Z14CityId = T00023_A14CityId[0];
               Z11CategoryId = T00023_A11CategoryId[0];
            }
            else
            {
               Z8AttractionName = A8AttractionName;
               Z9CountryId = A9CountryId;
               Z14CityId = A14CityId;
               Z11CategoryId = A11CategoryId;
            }
         }
         if ( GX_JID == -15 )
         {
            Z7AttractionId = A7AttractionId;
            Z8AttractionName = A8AttractionName;
            Z13AttractionPhoto = A13AttractionPhoto;
            Z40000AttractionPhoto_GXI = A40000AttractionPhoto_GXI;
            Z9CountryId = A9CountryId;
            Z14CityId = A14CityId;
            Z11CategoryId = A11CategoryId;
            Z10CountryName = A10CountryName;
            Z12CategoryName = A12CategoryName;
            Z15CityName = A15CityName;
         }
      }

      protected void standaloneNotModal( )
      {
         edtAttractionId_Enabled = 0;
         AssignProp("", false, edtAttractionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAttractionId_Enabled), 5, 0), true);
         imgprompt_9_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0030.aspx"+"',["+"{Ctrl:gx.dom.el('"+"COUNTRYID"+"'), id:'"+"COUNTRYID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_11_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0040.aspx"+"',["+"{Ctrl:gx.dom.el('"+"CATEGORYID"+"'), id:'"+"CATEGORYID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_14_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0051.aspx"+"',["+"{Ctrl:gx.dom.el('"+"COUNTRYID"+"'), id:'"+"COUNTRYID"+"'"+",IOType:'in'}"+","+"{Ctrl:gx.dom.el('"+"CITYID"+"'), id:'"+"CITYID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         edtAttractionId_Enabled = 0;
         AssignProp("", false, edtAttractionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAttractionId_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7AttractionId) )
         {
            A7AttractionId = AV7AttractionId;
            AssignAttri("", false, "A7AttractionId", StringUtil.LTrimStr( (decimal)(A7AttractionId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_CountryId) )
         {
            edtCountryId_Enabled = 0;
            AssignProp("", false, edtCountryId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCountryId_Enabled), 5, 0), true);
         }
         else
         {
            edtCountryId_Enabled = 1;
            AssignProp("", false, edtCountryId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCountryId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_CategoryId) )
         {
            edtCategoryId_Enabled = 0;
            AssignProp("", false, edtCategoryId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoryId_Enabled), 5, 0), true);
         }
         else
         {
            edtCategoryId_Enabled = 1;
            AssignProp("", false, edtCategoryId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoryId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_CityId) )
         {
            edtCityId_Enabled = 0;
            AssignProp("", false, edtCityId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCityId_Enabled), 5, 0), true);
         }
         else
         {
            edtCityId_Enabled = 1;
            AssignProp("", false, edtCityId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCityId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_CityId) )
         {
            A14CityId = AV13Insert_CityId;
            n14CityId = false;
            AssignAttri("", false, "A14CityId", StringUtil.LTrimStr( (decimal)(A14CityId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_CategoryId) )
         {
            A11CategoryId = AV12Insert_CategoryId;
            n11CategoryId = false;
            AssignAttri("", false, "A11CategoryId", StringUtil.LTrimStr( (decimal)(A11CategoryId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_CountryId) )
         {
            A9CountryId = AV11Insert_CountryId;
            AssignAttri("", false, "A9CountryId", StringUtil.LTrimStr( (decimal)(A9CountryId), 4, 0));
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            AV16Pgmname = "Attractions";
            AssignAttri("", false, "AV16Pgmname", AV16Pgmname);
            /* Using cursor T00026 */
            pr_default.execute(4, new Object[] {n11CategoryId, A11CategoryId});
            A12CategoryName = T00026_A12CategoryName[0];
            AssignAttri("", false, "A12CategoryName", A12CategoryName);
            pr_default.close(4);
            /* Using cursor T00024 */
            pr_default.execute(2, new Object[] {A9CountryId});
            A10CountryName = T00024_A10CountryName[0];
            AssignAttri("", false, "A10CountryName", A10CountryName);
            pr_default.close(2);
            /* Using cursor T00025 */
            pr_default.execute(3, new Object[] {A9CountryId, n14CityId, A14CityId});
            A15CityName = T00025_A15CityName[0];
            AssignAttri("", false, "A15CityName", A15CityName);
            pr_default.close(3);
         }
      }

      protected void Load022( )
      {
         /* Using cursor T00027 */
         pr_default.execute(5, new Object[] {A7AttractionId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound2 = 1;
            A8AttractionName = T00027_A8AttractionName[0];
            AssignAttri("", false, "A8AttractionName", A8AttractionName);
            A10CountryName = T00027_A10CountryName[0];
            AssignAttri("", false, "A10CountryName", A10CountryName);
            A12CategoryName = T00027_A12CategoryName[0];
            AssignAttri("", false, "A12CategoryName", A12CategoryName);
            A40000AttractionPhoto_GXI = T00027_A40000AttractionPhoto_GXI[0];
            AssignProp("", false, imgAttractionPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A13AttractionPhoto)) ? A40000AttractionPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A13AttractionPhoto))), true);
            AssignProp("", false, imgAttractionPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A13AttractionPhoto), true);
            A15CityName = T00027_A15CityName[0];
            AssignAttri("", false, "A15CityName", A15CityName);
            A9CountryId = T00027_A9CountryId[0];
            AssignAttri("", false, "A9CountryId", StringUtil.LTrimStr( (decimal)(A9CountryId), 4, 0));
            A14CityId = T00027_A14CityId[0];
            n14CityId = T00027_n14CityId[0];
            AssignAttri("", false, "A14CityId", StringUtil.LTrimStr( (decimal)(A14CityId), 4, 0));
            A11CategoryId = T00027_A11CategoryId[0];
            n11CategoryId = T00027_n11CategoryId[0];
            AssignAttri("", false, "A11CategoryId", StringUtil.LTrimStr( (decimal)(A11CategoryId), 4, 0));
            A13AttractionPhoto = T00027_A13AttractionPhoto[0];
            AssignAttri("", false, "A13AttractionPhoto", A13AttractionPhoto);
            AssignProp("", false, imgAttractionPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A13AttractionPhoto)) ? A40000AttractionPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A13AttractionPhoto))), true);
            AssignProp("", false, imgAttractionPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A13AttractionPhoto), true);
            ZM022( -15) ;
         }
         pr_default.close(5);
         OnLoadActions022( ) ;
      }

      protected void OnLoadActions022( )
      {
         AV16Pgmname = "Attractions";
         AssignAttri("", false, "AV16Pgmname", AV16Pgmname);
      }

      protected void CheckExtendedTable022( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV16Pgmname = "Attractions";
         AssignAttri("", false, "AV16Pgmname", AV16Pgmname);
         /* Using cursor T00028 */
         pr_default.execute(6, new Object[] {A8AttractionName, A7AttractionId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Attraction Name"}), 1, "ATTRACTIONNAME");
            AnyError = 1;
            GX_FocusControl = edtAttractionName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(6);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A8AttractionName)) )
         {
            GX_msglist.addItem("The attraction name must not be empty", 1, "ATTRACTIONNAME");
            AnyError = 1;
            GX_FocusControl = edtAttractionName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00024 */
         pr_default.execute(2, new Object[] {A9CountryId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'Country'.", "ForeignKeyNotFound", 1, "COUNTRYID");
            AnyError = 1;
            GX_FocusControl = edtCountryId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A10CountryName = T00024_A10CountryName[0];
         AssignAttri("", false, "A10CountryName", A10CountryName);
         pr_default.close(2);
         /* Using cursor T00025 */
         pr_default.execute(3, new Object[] {A9CountryId, n14CityId, A14CityId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A9CountryId) || (0==A14CityId) ) )
            {
               GX_msglist.addItem("No matching 'City'.", "ForeignKeyNotFound", 1, "CITYID");
               AnyError = 1;
               GX_FocusControl = edtCountryId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A15CityName = T00025_A15CityName[0];
         AssignAttri("", false, "A15CityName", A15CityName);
         pr_default.close(3);
         /* Using cursor T00026 */
         pr_default.execute(4, new Object[] {n11CategoryId, A11CategoryId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A11CategoryId) ) )
            {
               GX_msglist.addItem("No matching 'Category'.", "ForeignKeyNotFound", 1, "CATEGORYID");
               AnyError = 1;
               GX_FocusControl = edtCategoryId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A12CategoryName = T00026_A12CategoryName[0];
         AssignAttri("", false, "A12CategoryName", A12CategoryName);
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors022( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_17( short A9CountryId )
      {
         /* Using cursor T00029 */
         pr_default.execute(7, new Object[] {A9CountryId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No matching 'Country'.", "ForeignKeyNotFound", 1, "COUNTRYID");
            AnyError = 1;
            GX_FocusControl = edtCountryId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A10CountryName = T00029_A10CountryName[0];
         AssignAttri("", false, "A10CountryName", A10CountryName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A10CountryName))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_18( short A9CountryId ,
                                short A14CityId )
      {
         /* Using cursor T000210 */
         pr_default.execute(8, new Object[] {A9CountryId, n14CityId, A14CityId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            if ( ! ( (0==A9CountryId) || (0==A14CityId) ) )
            {
               GX_msglist.addItem("No matching 'City'.", "ForeignKeyNotFound", 1, "CITYID");
               AnyError = 1;
               GX_FocusControl = edtCountryId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A15CityName = T000210_A15CityName[0];
         AssignAttri("", false, "A15CityName", A15CityName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A15CityName))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void gxLoad_19( short A11CategoryId )
      {
         /* Using cursor T000211 */
         pr_default.execute(9, new Object[] {n11CategoryId, A11CategoryId});
         if ( (pr_default.getStatus(9) == 101) )
         {
            if ( ! ( (0==A11CategoryId) ) )
            {
               GX_msglist.addItem("No matching 'Category'.", "ForeignKeyNotFound", 1, "CATEGORYID");
               AnyError = 1;
               GX_FocusControl = edtCategoryId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A12CategoryName = T000211_A12CategoryName[0];
         AssignAttri("", false, "A12CategoryName", A12CategoryName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A12CategoryName))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void GetKey022( )
      {
         /* Using cursor T000212 */
         pr_default.execute(10, new Object[] {A7AttractionId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound2 = 1;
         }
         else
         {
            RcdFound2 = 0;
         }
         pr_default.close(10);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00023 */
         pr_default.execute(1, new Object[] {A7AttractionId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM022( 15) ;
            RcdFound2 = 1;
            A7AttractionId = T00023_A7AttractionId[0];
            AssignAttri("", false, "A7AttractionId", StringUtil.LTrimStr( (decimal)(A7AttractionId), 4, 0));
            A8AttractionName = T00023_A8AttractionName[0];
            AssignAttri("", false, "A8AttractionName", A8AttractionName);
            A40000AttractionPhoto_GXI = T00023_A40000AttractionPhoto_GXI[0];
            AssignProp("", false, imgAttractionPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A13AttractionPhoto)) ? A40000AttractionPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A13AttractionPhoto))), true);
            AssignProp("", false, imgAttractionPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A13AttractionPhoto), true);
            A9CountryId = T00023_A9CountryId[0];
            AssignAttri("", false, "A9CountryId", StringUtil.LTrimStr( (decimal)(A9CountryId), 4, 0));
            A14CityId = T00023_A14CityId[0];
            n14CityId = T00023_n14CityId[0];
            AssignAttri("", false, "A14CityId", StringUtil.LTrimStr( (decimal)(A14CityId), 4, 0));
            A11CategoryId = T00023_A11CategoryId[0];
            n11CategoryId = T00023_n11CategoryId[0];
            AssignAttri("", false, "A11CategoryId", StringUtil.LTrimStr( (decimal)(A11CategoryId), 4, 0));
            A13AttractionPhoto = T00023_A13AttractionPhoto[0];
            AssignAttri("", false, "A13AttractionPhoto", A13AttractionPhoto);
            AssignProp("", false, imgAttractionPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A13AttractionPhoto)) ? A40000AttractionPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A13AttractionPhoto))), true);
            AssignProp("", false, imgAttractionPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A13AttractionPhoto), true);
            Z7AttractionId = A7AttractionId;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load022( ) ;
            if ( AnyError == 1 )
            {
               RcdFound2 = 0;
               InitializeNonKey022( ) ;
            }
            Gx_mode = sMode2;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound2 = 0;
            InitializeNonKey022( ) ;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode2;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey022( ) ;
         if ( RcdFound2 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound2 = 0;
         /* Using cursor T000213 */
         pr_default.execute(11, new Object[] {A7AttractionId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( T000213_A7AttractionId[0] < A7AttractionId ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( T000213_A7AttractionId[0] > A7AttractionId ) ) )
            {
               A7AttractionId = T000213_A7AttractionId[0];
               AssignAttri("", false, "A7AttractionId", StringUtil.LTrimStr( (decimal)(A7AttractionId), 4, 0));
               RcdFound2 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void move_previous( )
      {
         RcdFound2 = 0;
         /* Using cursor T000214 */
         pr_default.execute(12, new Object[] {A7AttractionId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            while ( (pr_default.getStatus(12) != 101) && ( ( T000214_A7AttractionId[0] > A7AttractionId ) ) )
            {
               pr_default.readNext(12);
            }
            if ( (pr_default.getStatus(12) != 101) && ( ( T000214_A7AttractionId[0] < A7AttractionId ) ) )
            {
               A7AttractionId = T000214_A7AttractionId[0];
               AssignAttri("", false, "A7AttractionId", StringUtil.LTrimStr( (decimal)(A7AttractionId), 4, 0));
               RcdFound2 = 1;
            }
         }
         pr_default.close(12);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey022( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtAttractionName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert022( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound2 == 1 )
            {
               if ( A7AttractionId != Z7AttractionId )
               {
                  A7AttractionId = Z7AttractionId;
                  AssignAttri("", false, "A7AttractionId", StringUtil.LTrimStr( (decimal)(A7AttractionId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "ATTRACTIONID");
                  AnyError = 1;
                  GX_FocusControl = edtAttractionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtAttractionName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update022( ) ;
                  GX_FocusControl = edtAttractionName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A7AttractionId != Z7AttractionId )
               {
                  /* Insert record */
                  GX_FocusControl = edtAttractionName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert022( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ATTRACTIONID");
                     AnyError = 1;
                     GX_FocusControl = edtAttractionId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtAttractionName_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert022( ) ;
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
         if ( IsUpd( ) || IsDlt( ) )
         {
            if ( AnyError == 0 )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( A7AttractionId != Z7AttractionId )
         {
            A7AttractionId = Z7AttractionId;
            AssignAttri("", false, "A7AttractionId", StringUtil.LTrimStr( (decimal)(A7AttractionId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "ATTRACTIONID");
            AnyError = 1;
            GX_FocusControl = edtAttractionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtAttractionName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency022( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00022 */
            pr_default.execute(0, new Object[] {A7AttractionId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Attractions"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z8AttractionName, T00022_A8AttractionName[0]) != 0 ) || ( Z9CountryId != T00022_A9CountryId[0] ) || ( Z14CityId != T00022_A14CityId[0] ) || ( Z11CategoryId != T00022_A11CategoryId[0] ) )
            {
               if ( StringUtil.StrCmp(Z8AttractionName, T00022_A8AttractionName[0]) != 0 )
               {
                  GXUtil.WriteLog("attractions:[seudo value changed for attri]"+"AttractionName");
                  GXUtil.WriteLogRaw("Old: ",Z8AttractionName);
                  GXUtil.WriteLogRaw("Current: ",T00022_A8AttractionName[0]);
               }
               if ( Z9CountryId != T00022_A9CountryId[0] )
               {
                  GXUtil.WriteLog("attractions:[seudo value changed for attri]"+"CountryId");
                  GXUtil.WriteLogRaw("Old: ",Z9CountryId);
                  GXUtil.WriteLogRaw("Current: ",T00022_A9CountryId[0]);
               }
               if ( Z14CityId != T00022_A14CityId[0] )
               {
                  GXUtil.WriteLog("attractions:[seudo value changed for attri]"+"CityId");
                  GXUtil.WriteLogRaw("Old: ",Z14CityId);
                  GXUtil.WriteLogRaw("Current: ",T00022_A14CityId[0]);
               }
               if ( Z11CategoryId != T00022_A11CategoryId[0] )
               {
                  GXUtil.WriteLog("attractions:[seudo value changed for attri]"+"CategoryId");
                  GXUtil.WriteLogRaw("Old: ",Z11CategoryId);
                  GXUtil.WriteLogRaw("Current: ",T00022_A11CategoryId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Attractions"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert022( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable022( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM022( 0) ;
            CheckOptimisticConcurrency022( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm022( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert022( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000215 */
                     pr_default.execute(13, new Object[] {A8AttractionName, A13AttractionPhoto, A40000AttractionPhoto_GXI, A9CountryId, n14CityId, A14CityId, n11CategoryId, A11CategoryId});
                     A7AttractionId = T000215_A7AttractionId[0];
                     AssignAttri("", false, "A7AttractionId", StringUtil.LTrimStr( (decimal)(A7AttractionId), 4, 0));
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("Attractions");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption020( ) ;
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
               Load022( ) ;
            }
            EndLevel022( ) ;
         }
         CloseExtendedTableCursors022( ) ;
      }

      protected void Update022( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable022( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency022( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm022( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate022( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000216 */
                     pr_default.execute(14, new Object[] {A8AttractionName, A9CountryId, n14CityId, A14CityId, n11CategoryId, A11CategoryId, A7AttractionId});
                     pr_default.close(14);
                     pr_default.SmartCacheProvider.SetUpdated("Attractions");
                     if ( (pr_default.getStatus(14) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Attractions"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate022( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsUpd( ) || IsDlt( ) )
                           {
                              if ( AnyError == 0 )
                              {
                                 context.nUserReturn = 1;
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
            }
            EndLevel022( ) ;
         }
         CloseExtendedTableCursors022( ) ;
      }

      protected void DeferredUpdate022( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T000217 */
            pr_default.execute(15, new Object[] {A13AttractionPhoto, A40000AttractionPhoto_GXI, A7AttractionId});
            pr_default.close(15);
            pr_default.SmartCacheProvider.SetUpdated("Attractions");
         }
      }

      protected void delete( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency022( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls022( ) ;
            AfterConfirm022( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete022( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000218 */
                  pr_default.execute(16, new Object[] {A7AttractionId});
                  pr_default.close(16);
                  pr_default.SmartCacheProvider.SetUpdated("Attractions");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        if ( IsUpd( ) || IsDlt( ) )
                        {
                           if ( AnyError == 0 )
                           {
                              context.nUserReturn = 1;
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
         }
         sMode2 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel022( ) ;
         Gx_mode = sMode2;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls022( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV16Pgmname = "Attractions";
            AssignAttri("", false, "AV16Pgmname", AV16Pgmname);
            /* Using cursor T000219 */
            pr_default.execute(17, new Object[] {A9CountryId});
            A10CountryName = T000219_A10CountryName[0];
            AssignAttri("", false, "A10CountryName", A10CountryName);
            pr_default.close(17);
            /* Using cursor T000220 */
            pr_default.execute(18, new Object[] {n11CategoryId, A11CategoryId});
            A12CategoryName = T000220_A12CategoryName[0];
            AssignAttri("", false, "A12CategoryName", A12CategoryName);
            pr_default.close(18);
            /* Using cursor T000221 */
            pr_default.execute(19, new Object[] {A9CountryId, n14CityId, A14CityId});
            A15CityName = T000221_A15CityName[0];
            AssignAttri("", false, "A15CityName", A15CityName);
            pr_default.close(19);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000222 */
            pr_default.execute(20, new Object[] {A7AttractionId});
            if ( (pr_default.getStatus(20) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Attraction"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(20);
         }
      }

      protected void EndLevel022( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete022( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(17);
            pr_default.close(19);
            pr_default.close(18);
            context.CommitDataStores("attractions",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues020( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(17);
            pr_default.close(19);
            pr_default.close(18);
            context.RollbackDataStores("attractions",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart022( )
      {
         /* Scan By routine */
         /* Using cursor T000223 */
         pr_default.execute(21);
         RcdFound2 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound2 = 1;
            A7AttractionId = T000223_A7AttractionId[0];
            AssignAttri("", false, "A7AttractionId", StringUtil.LTrimStr( (decimal)(A7AttractionId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext022( )
      {
         /* Scan next routine */
         pr_default.readNext(21);
         RcdFound2 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound2 = 1;
            A7AttractionId = T000223_A7AttractionId[0];
            AssignAttri("", false, "A7AttractionId", StringUtil.LTrimStr( (decimal)(A7AttractionId), 4, 0));
         }
      }

      protected void ScanEnd022( )
      {
         pr_default.close(21);
      }

      protected void AfterConfirm022( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert022( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate022( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete022( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete022( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate022( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes022( )
      {
         edtAttractionId_Enabled = 0;
         AssignProp("", false, edtAttractionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAttractionId_Enabled), 5, 0), true);
         edtAttractionName_Enabled = 0;
         AssignProp("", false, edtAttractionName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAttractionName_Enabled), 5, 0), true);
         edtCountryId_Enabled = 0;
         AssignProp("", false, edtCountryId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCountryId_Enabled), 5, 0), true);
         edtCountryName_Enabled = 0;
         AssignProp("", false, edtCountryName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCountryName_Enabled), 5, 0), true);
         edtCategoryId_Enabled = 0;
         AssignProp("", false, edtCategoryId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoryId_Enabled), 5, 0), true);
         edtCategoryName_Enabled = 0;
         AssignProp("", false, edtCategoryName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoryName_Enabled), 5, 0), true);
         imgAttractionPhoto_Enabled = 0;
         AssignProp("", false, imgAttractionPhoto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgAttractionPhoto_Enabled), 5, 0), true);
         edtCityId_Enabled = 0;
         AssignProp("", false, edtCityId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCityId_Enabled), 5, 0), true);
         edtCityName_Enabled = 0;
         AssignProp("", false, edtCityName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCityName_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes022( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues020( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("attractions.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7AttractionId,4,0))}, new string[] {"Gx_mode","AttractionId"}) +"\">") ;
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
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"Attractions");
         forbiddenHiddens.Add("AttractionId", context.localUtil.Format( (decimal)(A7AttractionId), "ZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("attractions:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z7AttractionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z7AttractionId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z8AttractionName", StringUtil.RTrim( Z8AttractionName));
         GxWebStd.gx_hidden_field( context, "Z9CountryId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z9CountryId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z14CityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z14CityId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z11CategoryId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z11CategoryId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N9CountryId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A9CountryId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "N11CategoryId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A11CategoryId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "N14CityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A14CityId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV9TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV9TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vATTRACTIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7AttractionId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vATTRACTIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7AttractionId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_COUNTRYID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_CountryId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_CATEGORYID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12Insert_CategoryId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_CITYID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13Insert_CityId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ATTRACTIONPHOTO_GXI", A40000AttractionPhoto_GXI);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV16Pgmname));
         GXCCtlgxBlob = "ATTRACTIONPHOTO" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A13AttractionPhoto);
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
         return formatLink("attractions.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7AttractionId,4,0))}, new string[] {"Gx_mode","AttractionId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Attractions" ;
      }

      public override string GetPgmdesc( )
      {
         return "Attractions" ;
      }

      protected void InitializeNonKey022( )
      {
         A9CountryId = 0;
         AssignAttri("", false, "A9CountryId", StringUtil.LTrimStr( (decimal)(A9CountryId), 4, 0));
         A11CategoryId = 0;
         n11CategoryId = false;
         AssignAttri("", false, "A11CategoryId", StringUtil.LTrimStr( (decimal)(A11CategoryId), 4, 0));
         n11CategoryId = ((0==A11CategoryId) ? true : false);
         A14CityId = 0;
         n14CityId = false;
         AssignAttri("", false, "A14CityId", StringUtil.LTrimStr( (decimal)(A14CityId), 4, 0));
         n14CityId = ((0==A14CityId) ? true : false);
         A8AttractionName = "";
         AssignAttri("", false, "A8AttractionName", A8AttractionName);
         A10CountryName = "";
         AssignAttri("", false, "A10CountryName", A10CountryName);
         A12CategoryName = "";
         AssignAttri("", false, "A12CategoryName", A12CategoryName);
         A13AttractionPhoto = "";
         AssignAttri("", false, "A13AttractionPhoto", A13AttractionPhoto);
         AssignProp("", false, imgAttractionPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A13AttractionPhoto)) ? A40000AttractionPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A13AttractionPhoto))), true);
         AssignProp("", false, imgAttractionPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A13AttractionPhoto), true);
         A40000AttractionPhoto_GXI = "";
         AssignProp("", false, imgAttractionPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A13AttractionPhoto)) ? A40000AttractionPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A13AttractionPhoto))), true);
         AssignProp("", false, imgAttractionPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A13AttractionPhoto), true);
         A15CityName = "";
         AssignAttri("", false, "A15CityName", A15CityName);
         Z8AttractionName = "";
         Z9CountryId = 0;
         Z14CityId = 0;
         Z11CategoryId = 0;
      }

      protected void InitAll022( )
      {
         A7AttractionId = 0;
         AssignAttri("", false, "A7AttractionId", StringUtil.LTrimStr( (decimal)(A7AttractionId), 4, 0));
         InitializeNonKey022( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20262142055193", true, true);
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
         context.AddJavascriptSource("attractions.js", "?20262142055193", false, true);
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
         edtAttractionId_Internalname = "ATTRACTIONID";
         edtAttractionName_Internalname = "ATTRACTIONNAME";
         edtCountryId_Internalname = "COUNTRYID";
         edtCountryName_Internalname = "COUNTRYNAME";
         edtCategoryId_Internalname = "CATEGORYID";
         edtCategoryName_Internalname = "CATEGORYNAME";
         imgAttractionPhoto_Internalname = "ATTRACTIONPHOTO";
         edtCityId_Internalname = "CITYID";
         edtCityName_Internalname = "CITYNAME";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_9_Internalname = "PROMPT_9";
         imgprompt_11_Internalname = "PROMPT_11";
         imgprompt_14_Internalname = "PROMPT_14";
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
         Form.Caption = "Attractions";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Tooltiptext = "Confirm";
         bttBtn_enter_Caption = "Confirm";
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtCityName_Jsonclick = "";
         edtCityName_Enabled = 0;
         imgprompt_14_Visible = 1;
         imgprompt_14_Link = "";
         edtCityId_Jsonclick = "";
         edtCityId_Enabled = 1;
         imgAttractionPhoto_Enabled = 1;
         edtCategoryName_Jsonclick = "";
         edtCategoryName_Enabled = 0;
         imgprompt_11_Visible = 1;
         imgprompt_11_Link = "";
         edtCategoryId_Jsonclick = "";
         edtCategoryId_Enabled = 1;
         edtCountryName_Jsonclick = "";
         edtCountryName_Enabled = 0;
         imgprompt_9_Visible = 1;
         imgprompt_9_Link = "";
         edtCountryId_Jsonclick = "";
         edtCountryId_Enabled = 1;
         edtAttractionName_Jsonclick = "";
         edtAttractionName_Enabled = 1;
         edtAttractionId_Jsonclick = "";
         edtAttractionId_Enabled = 0;
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

      public void Valid_Attractionname( )
      {
         /* Using cursor T000224 */
         pr_default.execute(22, new Object[] {A8AttractionName, A7AttractionId});
         if ( (pr_default.getStatus(22) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Attraction Name"}), 1, "ATTRACTIONNAME");
            AnyError = 1;
            GX_FocusControl = edtAttractionName_Internalname;
         }
         pr_default.close(22);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A8AttractionName)) )
         {
            GX_msglist.addItem("The attraction name must not be empty", 1, "ATTRACTIONNAME");
            AnyError = 1;
            GX_FocusControl = edtAttractionName_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Countryid( )
      {
         /* Using cursor T000219 */
         pr_default.execute(17, new Object[] {A9CountryId});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem("No matching 'Country'.", "ForeignKeyNotFound", 1, "COUNTRYID");
            AnyError = 1;
            GX_FocusControl = edtCountryId_Internalname;
         }
         A10CountryName = T000219_A10CountryName[0];
         pr_default.close(17);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A10CountryName", StringUtil.RTrim( A10CountryName));
      }

      public void Valid_Categoryid( )
      {
         n11CategoryId = false;
         /* Using cursor T000220 */
         pr_default.execute(18, new Object[] {n11CategoryId, A11CategoryId});
         if ( (pr_default.getStatus(18) == 101) )
         {
            if ( ! ( (0==A11CategoryId) ) )
            {
               GX_msglist.addItem("No matching 'Category'.", "ForeignKeyNotFound", 1, "CATEGORYID");
               AnyError = 1;
               GX_FocusControl = edtCategoryId_Internalname;
            }
         }
         A12CategoryName = T000220_A12CategoryName[0];
         pr_default.close(18);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A12CategoryName", StringUtil.RTrim( A12CategoryName));
      }

      public void Valid_Cityid( )
      {
         n14CityId = false;
         /* Using cursor T000221 */
         pr_default.execute(19, new Object[] {A9CountryId, n14CityId, A14CityId});
         if ( (pr_default.getStatus(19) == 101) )
         {
            if ( ! ( (0==A9CountryId) || (0==A14CityId) ) )
            {
               GX_msglist.addItem("No matching 'City'.", "ForeignKeyNotFound", 1, "CITYID");
               AnyError = 1;
               GX_FocusControl = edtCountryId_Internalname;
            }
         }
         A15CityName = T000221_A15CityName[0];
         pr_default.close(19);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A15CityName", StringUtil.RTrim( A15CityName));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7AttractionId","fld":"vATTRACTIONID","pic":"ZZZ9","hsh":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7AttractionId","fld":"vATTRACTIONID","pic":"ZZZ9","hsh":true},{"av":"A7AttractionId","fld":"ATTRACTIONID","pic":"ZZZ9"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E12022","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true}]}""");
         setEventMetadata("VALID_ATTRACTIONID","""{"handler":"Valid_Attractionid","iparms":[]}""");
         setEventMetadata("VALID_ATTRACTIONNAME","""{"handler":"Valid_Attractionname","iparms":[{"av":"A8AttractionName","fld":"ATTRACTIONNAME"},{"av":"A7AttractionId","fld":"ATTRACTIONID","pic":"ZZZ9"}]}""");
         setEventMetadata("VALID_COUNTRYID","""{"handler":"Valid_Countryid","iparms":[{"av":"A9CountryId","fld":"COUNTRYID","pic":"ZZZ9"},{"av":"A10CountryName","fld":"COUNTRYNAME"}]""");
         setEventMetadata("VALID_COUNTRYID",""","oparms":[{"av":"A10CountryName","fld":"COUNTRYNAME"}]}""");
         setEventMetadata("VALID_CATEGORYID","""{"handler":"Valid_Categoryid","iparms":[{"av":"A11CategoryId","fld":"CATEGORYID","pic":"ZZZ9"},{"av":"A12CategoryName","fld":"CATEGORYNAME"}]""");
         setEventMetadata("VALID_CATEGORYID",""","oparms":[{"av":"A12CategoryName","fld":"CATEGORYNAME"}]}""");
         setEventMetadata("VALID_CITYID","""{"handler":"Valid_Cityid","iparms":[{"av":"A9CountryId","fld":"COUNTRYID","pic":"ZZZ9"},{"av":"A14CityId","fld":"CITYID","pic":"ZZZ9"},{"av":"A15CityName","fld":"CITYNAME"}]""");
         setEventMetadata("VALID_CITYID",""","oparms":[{"av":"A15CityName","fld":"CITYNAME"}]}""");
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
         pr_default.close(17);
         pr_default.close(19);
         pr_default.close(18);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z8AttractionName = "";
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
         A8AttractionName = "";
         imgprompt_9_gximage = "";
         sImgUrl = "";
         A10CountryName = "";
         imgprompt_11_gximage = "";
         A12CategoryName = "";
         A13AttractionPhoto = "";
         A40000AttractionPhoto_GXI = "";
         imgprompt_14_gximage = "";
         A15CityName = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         AV16Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode2 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV14TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         Z13AttractionPhoto = "";
         Z40000AttractionPhoto_GXI = "";
         Z10CountryName = "";
         Z12CategoryName = "";
         Z15CityName = "";
         T00026_A12CategoryName = new string[] {""} ;
         T00024_A10CountryName = new string[] {""} ;
         T00025_A15CityName = new string[] {""} ;
         T00027_A7AttractionId = new short[1] ;
         T00027_A8AttractionName = new string[] {""} ;
         T00027_A10CountryName = new string[] {""} ;
         T00027_A12CategoryName = new string[] {""} ;
         T00027_A40000AttractionPhoto_GXI = new string[] {""} ;
         T00027_A15CityName = new string[] {""} ;
         T00027_A9CountryId = new short[1] ;
         T00027_A14CityId = new short[1] ;
         T00027_n14CityId = new bool[] {false} ;
         T00027_A11CategoryId = new short[1] ;
         T00027_n11CategoryId = new bool[] {false} ;
         T00027_A13AttractionPhoto = new string[] {""} ;
         T00028_A8AttractionName = new string[] {""} ;
         T00029_A10CountryName = new string[] {""} ;
         T000210_A15CityName = new string[] {""} ;
         T000211_A12CategoryName = new string[] {""} ;
         T000212_A7AttractionId = new short[1] ;
         T00023_A7AttractionId = new short[1] ;
         T00023_A8AttractionName = new string[] {""} ;
         T00023_A40000AttractionPhoto_GXI = new string[] {""} ;
         T00023_A9CountryId = new short[1] ;
         T00023_A14CityId = new short[1] ;
         T00023_n14CityId = new bool[] {false} ;
         T00023_A11CategoryId = new short[1] ;
         T00023_n11CategoryId = new bool[] {false} ;
         T00023_A13AttractionPhoto = new string[] {""} ;
         T000213_A7AttractionId = new short[1] ;
         T000214_A7AttractionId = new short[1] ;
         T00022_A7AttractionId = new short[1] ;
         T00022_A8AttractionName = new string[] {""} ;
         T00022_A40000AttractionPhoto_GXI = new string[] {""} ;
         T00022_A9CountryId = new short[1] ;
         T00022_A14CityId = new short[1] ;
         T00022_n14CityId = new bool[] {false} ;
         T00022_A11CategoryId = new short[1] ;
         T00022_n11CategoryId = new bool[] {false} ;
         T00022_A13AttractionPhoto = new string[] {""} ;
         T000215_A7AttractionId = new short[1] ;
         T000219_A10CountryName = new string[] {""} ;
         T000220_A12CategoryName = new string[] {""} ;
         T000221_A15CityName = new string[] {""} ;
         T000222_A45SupplierId = new short[1] ;
         T000222_A7AttractionId = new short[1] ;
         T000223_A7AttractionId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         T000224_A8AttractionName = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.attractions__default(),
            new Object[][] {
                new Object[] {
               T00022_A7AttractionId, T00022_A8AttractionName, T00022_A40000AttractionPhoto_GXI, T00022_A9CountryId, T00022_A14CityId, T00022_n14CityId, T00022_A11CategoryId, T00022_n11CategoryId, T00022_A13AttractionPhoto
               }
               , new Object[] {
               T00023_A7AttractionId, T00023_A8AttractionName, T00023_A40000AttractionPhoto_GXI, T00023_A9CountryId, T00023_A14CityId, T00023_n14CityId, T00023_A11CategoryId, T00023_n11CategoryId, T00023_A13AttractionPhoto
               }
               , new Object[] {
               T00024_A10CountryName
               }
               , new Object[] {
               T00025_A15CityName
               }
               , new Object[] {
               T00026_A12CategoryName
               }
               , new Object[] {
               T00027_A7AttractionId, T00027_A8AttractionName, T00027_A10CountryName, T00027_A12CategoryName, T00027_A40000AttractionPhoto_GXI, T00027_A15CityName, T00027_A9CountryId, T00027_A14CityId, T00027_n14CityId, T00027_A11CategoryId,
               T00027_n11CategoryId, T00027_A13AttractionPhoto
               }
               , new Object[] {
               T00028_A8AttractionName
               }
               , new Object[] {
               T00029_A10CountryName
               }
               , new Object[] {
               T000210_A15CityName
               }
               , new Object[] {
               T000211_A12CategoryName
               }
               , new Object[] {
               T000212_A7AttractionId
               }
               , new Object[] {
               T000213_A7AttractionId
               }
               , new Object[] {
               T000214_A7AttractionId
               }
               , new Object[] {
               T000215_A7AttractionId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000219_A10CountryName
               }
               , new Object[] {
               T000220_A12CategoryName
               }
               , new Object[] {
               T000221_A15CityName
               }
               , new Object[] {
               T000222_A45SupplierId, T000222_A7AttractionId
               }
               , new Object[] {
               T000223_A7AttractionId
               }
               , new Object[] {
               T000224_A8AttractionName
               }
            }
         );
         AV16Pgmname = "Attractions";
      }

      private short wcpOAV7AttractionId ;
      private short Z7AttractionId ;
      private short Z9CountryId ;
      private short Z14CityId ;
      private short Z11CategoryId ;
      private short N9CountryId ;
      private short N11CategoryId ;
      private short N14CityId ;
      private short GxWebError ;
      private short A9CountryId ;
      private short A14CityId ;
      private short A11CategoryId ;
      private short AV7AttractionId ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A7AttractionId ;
      private short AV11Insert_CountryId ;
      private short AV12Insert_CategoryId ;
      private short AV13Insert_CityId ;
      private short RcdFound2 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtAttractionId_Enabled ;
      private int edtAttractionName_Enabled ;
      private int edtCountryId_Enabled ;
      private int imgprompt_9_Visible ;
      private int edtCountryName_Enabled ;
      private int edtCategoryId_Enabled ;
      private int imgprompt_11_Visible ;
      private int edtCategoryName_Enabled ;
      private int imgAttractionPhoto_Enabled ;
      private int edtCityId_Enabled ;
      private int imgprompt_14_Visible ;
      private int edtCityName_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int AV17GXV1 ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z8AttractionName ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtAttractionName_Internalname ;
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
      private string edtAttractionId_Internalname ;
      private string edtAttractionId_Jsonclick ;
      private string A8AttractionName ;
      private string edtAttractionName_Jsonclick ;
      private string edtCountryId_Internalname ;
      private string edtCountryId_Jsonclick ;
      private string imgprompt_9_gximage ;
      private string sImgUrl ;
      private string imgprompt_9_Internalname ;
      private string imgprompt_9_Link ;
      private string edtCountryName_Internalname ;
      private string A10CountryName ;
      private string edtCountryName_Jsonclick ;
      private string edtCategoryId_Internalname ;
      private string edtCategoryId_Jsonclick ;
      private string imgprompt_11_gximage ;
      private string imgprompt_11_Internalname ;
      private string imgprompt_11_Link ;
      private string edtCategoryName_Internalname ;
      private string A12CategoryName ;
      private string edtCategoryName_Jsonclick ;
      private string imgAttractionPhoto_Internalname ;
      private string edtCityId_Internalname ;
      private string edtCityId_Jsonclick ;
      private string imgprompt_14_gximage ;
      private string imgprompt_14_Internalname ;
      private string imgprompt_14_Link ;
      private string edtCityName_Internalname ;
      private string A15CityName ;
      private string edtCityName_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Caption ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_enter_Tooltiptext ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string AV16Pgmname ;
      private string hsh ;
      private string sMode2 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z10CountryName ;
      private string Z12CategoryName ;
      private string Z15CityName ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXCCtlgxBlob ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n14CityId ;
      private bool n11CategoryId ;
      private bool wbErr ;
      private bool A13AttractionPhoto_IsBlob ;
      private bool returnInSub ;
      private string A40000AttractionPhoto_GXI ;
      private string Z40000AttractionPhoto_GXI ;
      private string A13AttractionPhoto ;
      private string Z13AttractionPhoto ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV9TrnContext ;
      private GeneXus.Programs.general.ui.SdtTransactionContext_Attribute AV14TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private string[] T00026_A12CategoryName ;
      private string[] T00024_A10CountryName ;
      private string[] T00025_A15CityName ;
      private short[] T00027_A7AttractionId ;
      private string[] T00027_A8AttractionName ;
      private string[] T00027_A10CountryName ;
      private string[] T00027_A12CategoryName ;
      private string[] T00027_A40000AttractionPhoto_GXI ;
      private string[] T00027_A15CityName ;
      private short[] T00027_A9CountryId ;
      private short[] T00027_A14CityId ;
      private bool[] T00027_n14CityId ;
      private short[] T00027_A11CategoryId ;
      private bool[] T00027_n11CategoryId ;
      private string[] T00027_A13AttractionPhoto ;
      private string[] T00028_A8AttractionName ;
      private string[] T00029_A10CountryName ;
      private string[] T000210_A15CityName ;
      private string[] T000211_A12CategoryName ;
      private short[] T000212_A7AttractionId ;
      private short[] T00023_A7AttractionId ;
      private string[] T00023_A8AttractionName ;
      private string[] T00023_A40000AttractionPhoto_GXI ;
      private short[] T00023_A9CountryId ;
      private short[] T00023_A14CityId ;
      private bool[] T00023_n14CityId ;
      private short[] T00023_A11CategoryId ;
      private bool[] T00023_n11CategoryId ;
      private string[] T00023_A13AttractionPhoto ;
      private short[] T000213_A7AttractionId ;
      private short[] T000214_A7AttractionId ;
      private short[] T00022_A7AttractionId ;
      private string[] T00022_A8AttractionName ;
      private string[] T00022_A40000AttractionPhoto_GXI ;
      private short[] T00022_A9CountryId ;
      private short[] T00022_A14CityId ;
      private bool[] T00022_n14CityId ;
      private short[] T00022_A11CategoryId ;
      private bool[] T00022_n11CategoryId ;
      private string[] T00022_A13AttractionPhoto ;
      private short[] T000215_A7AttractionId ;
      private string[] T000219_A10CountryName ;
      private string[] T000220_A12CategoryName ;
      private string[] T000221_A15CityName ;
      private short[] T000222_A45SupplierId ;
      private short[] T000222_A7AttractionId ;
      private short[] T000223_A7AttractionId ;
      private string[] T000224_A8AttractionName ;
   }

   public class attractions__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[14])
         ,new UpdateCursor(def[15])
         ,new UpdateCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new ForEachCursor(def[21])
         ,new ForEachCursor(def[22])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00022;
          prmT00022 = new Object[] {
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          Object[] prmT00023;
          prmT00023 = new Object[] {
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          Object[] prmT00024;
          prmT00024 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmT00025;
          prmT00025 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0) ,
          new ParDef("@CityId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT00026;
          prmT00026 = new Object[] {
          new ParDef("@CategoryId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT00027;
          prmT00027 = new Object[] {
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          Object[] prmT00028;
          prmT00028 = new Object[] {
          new ParDef("@AttractionName",GXType.NChar,50,0) ,
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          Object[] prmT00029;
          prmT00029 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmT000210;
          prmT000210 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0) ,
          new ParDef("@CityId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000211;
          prmT000211 = new Object[] {
          new ParDef("@CategoryId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000212;
          prmT000212 = new Object[] {
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          Object[] prmT000213;
          prmT000213 = new Object[] {
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          Object[] prmT000214;
          prmT000214 = new Object[] {
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          Object[] prmT000215;
          prmT000215 = new Object[] {
          new ParDef("@AttractionName",GXType.NChar,50,0) ,
          new ParDef("@AttractionPhoto",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@AttractionPhoto_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=1, Tbl="Attractions", Fld="AttractionPhoto"} ,
          new ParDef("@CountryId",GXType.Int16,4,0) ,
          new ParDef("@CityId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@CategoryId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000216;
          prmT000216 = new Object[] {
          new ParDef("@AttractionName",GXType.NChar,50,0) ,
          new ParDef("@CountryId",GXType.Int16,4,0) ,
          new ParDef("@CityId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@CategoryId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          Object[] prmT000217;
          prmT000217 = new Object[] {
          new ParDef("@AttractionPhoto",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@AttractionPhoto_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Attractions", Fld="AttractionPhoto"} ,
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          Object[] prmT000218;
          prmT000218 = new Object[] {
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          Object[] prmT000219;
          prmT000219 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmT000220;
          prmT000220 = new Object[] {
          new ParDef("@CategoryId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000221;
          prmT000221 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0) ,
          new ParDef("@CityId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000222;
          prmT000222 = new Object[] {
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          Object[] prmT000223;
          prmT000223 = new Object[] {
          };
          Object[] prmT000224;
          prmT000224 = new Object[] {
          new ParDef("@AttractionName",GXType.NChar,50,0) ,
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00022", "SELECT [AttractionId], [AttractionName], [AttractionPhoto_GXI], [CountryId], [CityId], [CategoryId], [AttractionPhoto] FROM [Attractions] WITH (UPDLOCK) WHERE [AttractionId] = @AttractionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00022,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00023", "SELECT [AttractionId], [AttractionName], [AttractionPhoto_GXI], [CountryId], [CityId], [CategoryId], [AttractionPhoto] FROM [Attractions] WHERE [AttractionId] = @AttractionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00023,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00024", "SELECT [CountryName] FROM [Country] WHERE [CountryId] = @CountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00024,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00025", "SELECT [CityName] FROM [CountryCity] WHERE [CountryId] = @CountryId AND [CityId] = @CityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00025,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00026", "SELECT [CategoryName] FROM [Category] WHERE [CategoryId] = @CategoryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00026,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00027", "SELECT TM1.[AttractionId], TM1.[AttractionName], T2.[CountryName], T3.[CategoryName], TM1.[AttractionPhoto_GXI], T4.[CityName], TM1.[CountryId], TM1.[CityId], TM1.[CategoryId], TM1.[AttractionPhoto] FROM ((([Attractions] TM1 INNER JOIN [Country] T2 ON T2.[CountryId] = TM1.[CountryId]) LEFT JOIN [Category] T3 ON T3.[CategoryId] = TM1.[CategoryId]) LEFT JOIN [CountryCity] T4 ON T4.[CountryId] = TM1.[CountryId] AND T4.[CityId] = TM1.[CityId]) WHERE TM1.[AttractionId] = @AttractionId ORDER BY TM1.[AttractionId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00027,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00028", "SELECT [AttractionName] FROM [Attractions] WHERE ([AttractionName] = @AttractionName) AND (Not ( [AttractionId] = @AttractionId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT00028,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00029", "SELECT [CountryName] FROM [Country] WHERE [CountryId] = @CountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00029,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000210", "SELECT [CityName] FROM [CountryCity] WHERE [CountryId] = @CountryId AND [CityId] = @CityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000210,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000211", "SELECT [CategoryName] FROM [Category] WHERE [CategoryId] = @CategoryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000211,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000212", "SELECT [AttractionId] FROM [Attractions] WHERE [AttractionId] = @AttractionId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000212,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000213", "SELECT TOP 1 [AttractionId] FROM [Attractions] WHERE ( [AttractionId] > @AttractionId) ORDER BY [AttractionId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000213,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000214", "SELECT TOP 1 [AttractionId] FROM [Attractions] WHERE ( [AttractionId] < @AttractionId) ORDER BY [AttractionId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000214,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000215", "INSERT INTO [Attractions]([AttractionName], [AttractionPhoto], [AttractionPhoto_GXI], [CountryId], [CityId], [CategoryId]) VALUES(@AttractionName, @AttractionPhoto, @AttractionPhoto_GXI, @CountryId, @CityId, @CategoryId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000215,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000216", "UPDATE [Attractions] SET [AttractionName]=@AttractionName, [CountryId]=@CountryId, [CityId]=@CityId, [CategoryId]=@CategoryId  WHERE [AttractionId] = @AttractionId", GxErrorMask.GX_NOMASK,prmT000216)
             ,new CursorDef("T000217", "UPDATE [Attractions] SET [AttractionPhoto]=@AttractionPhoto, [AttractionPhoto_GXI]=@AttractionPhoto_GXI  WHERE [AttractionId] = @AttractionId", GxErrorMask.GX_NOMASK,prmT000217)
             ,new CursorDef("T000218", "DELETE FROM [Attractions]  WHERE [AttractionId] = @AttractionId", GxErrorMask.GX_NOMASK,prmT000218)
             ,new CursorDef("T000219", "SELECT [CountryName] FROM [Country] WHERE [CountryId] = @CountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000219,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000220", "SELECT [CategoryName] FROM [Category] WHERE [CategoryId] = @CategoryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000220,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000221", "SELECT [CityName] FROM [CountryCity] WHERE [CountryId] = @CountryId AND [CityId] = @CityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000221,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000222", "SELECT TOP 1 [SupplierId], [AttractionId] FROM [SupplierAttraction] WHERE [AttractionId] = @AttractionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000222,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000223", "SELECT [AttractionId] FROM [Attractions] ORDER BY [AttractionId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000223,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000224", "SELECT [AttractionName] FROM [Attractions] WHERE ([AttractionName] = @AttractionName) AND (Not ( [AttractionId] = @AttractionId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000224,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((string[]) buf[8])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(3));
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((string[]) buf[8])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(3));
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                ((string[]) buf[2])[0] = rslt.getString(3, 50);
                ((string[]) buf[3])[0] = rslt.getString(4, 50);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 50);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                ((short[]) buf[9])[0] = rslt.getShort(9);
                ((bool[]) buf[10])[0] = rslt.wasNull(9);
                ((string[]) buf[11])[0] = rslt.getMultimediaFile(10, rslt.getVarchar(5));
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 11 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 13 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 17 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 18 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 19 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 20 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 21 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 22 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
       }
    }

 }

}
