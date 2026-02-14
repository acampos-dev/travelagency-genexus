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
   public class category_bc : GxSilentTrn, IGxSilentTrn
   {
      public category_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("TravelAgency", true);
      }

      public category_bc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      protected void INITTRN( )
      {
      }

      public void GetInsDefault( )
      {
         ReadRow044( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey044( ) ;
         standaloneModal( ) ;
         AddRow044( ) ;
         Gx_mode = "INS";
         return  ;
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
               Z11CategoryId = A11CategoryId;
               SetMode( "UPD") ;
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

      public bool Reindex( )
      {
         return true ;
      }

      protected void CONFIRM_040( )
      {
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls044( ) ;
            }
            else
            {
               CheckExtendedTable044( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors044( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM044( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            Z12CategoryName = A12CategoryName;
         }
         if ( GX_JID == -1 )
         {
            Z11CategoryId = A11CategoryId;
            Z12CategoryName = A12CategoryName;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load044( )
      {
         /* Using cursor BC00044 */
         pr_default.execute(2, new Object[] {n11CategoryId, A11CategoryId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound4 = 1;
            A12CategoryName = BC00044_A12CategoryName[0];
            ZM044( -1) ;
         }
         pr_default.close(2);
         OnLoadActions044( ) ;
      }

      protected void OnLoadActions044( )
      {
      }

      protected void CheckExtendedTable044( )
      {
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors044( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey044( )
      {
         /* Using cursor BC00045 */
         pr_default.execute(3, new Object[] {n11CategoryId, A11CategoryId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound4 = 1;
         }
         else
         {
            RcdFound4 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00043 */
         pr_default.execute(1, new Object[] {n11CategoryId, A11CategoryId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM044( 1) ;
            RcdFound4 = 1;
            A11CategoryId = BC00043_A11CategoryId[0];
            n11CategoryId = BC00043_n11CategoryId[0];
            A12CategoryName = BC00043_A12CategoryName[0];
            Z11CategoryId = A11CategoryId;
            sMode4 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load044( ) ;
            if ( AnyError == 1 )
            {
               RcdFound4 = 0;
               InitializeNonKey044( ) ;
            }
            Gx_mode = sMode4;
         }
         else
         {
            RcdFound4 = 0;
            InitializeNonKey044( ) ;
            sMode4 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode4;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey044( ) ;
         if ( RcdFound4 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
         }
         getByPrimaryKey( ) ;
      }

      protected void insert_Check( )
      {
         CONFIRM_040( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency044( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00042 */
            pr_default.execute(0, new Object[] {n11CategoryId, A11CategoryId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Category"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z12CategoryName, BC00042_A12CategoryName[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Category"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert044( )
      {
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable044( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM044( 0) ;
            CheckOptimisticConcurrency044( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm044( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert044( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00046 */
                     pr_default.execute(4, new Object[] {A12CategoryName});
                     A11CategoryId = BC00046_A11CategoryId[0];
                     n11CategoryId = BC00046_n11CategoryId[0];
                     pr_default.close(4);
                     pr_default.SmartCacheProvider.SetUpdated("Category");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
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
               Load044( ) ;
            }
            EndLevel044( ) ;
         }
         CloseExtendedTableCursors044( ) ;
      }

      protected void Update044( )
      {
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable044( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency044( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm044( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate044( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00047 */
                     pr_default.execute(5, new Object[] {A12CategoryName, n11CategoryId, A11CategoryId});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Category");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Category"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate044( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
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
            EndLevel044( ) ;
         }
         CloseExtendedTableCursors044( ) ;
      }

      protected void DeferredUpdate044( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency044( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls044( ) ;
            AfterConfirm044( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete044( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00048 */
                  pr_default.execute(6, new Object[] {n11CategoryId, A11CategoryId});
                  pr_default.close(6);
                  pr_default.SmartCacheProvider.SetUpdated("Category");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
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
         sMode4 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel044( ) ;
         Gx_mode = sMode4;
      }

      protected void OnDeleteControls044( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC00049 */
            pr_default.execute(7, new Object[] {n11CategoryId, A11CategoryId});
            if ( (pr_default.getStatus(7) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Attractions"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(7);
         }
      }

      protected void EndLevel044( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete044( ) ;
         }
         if ( AnyError == 0 )
         {
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart044( )
      {
         /* Using cursor BC000410 */
         pr_default.execute(8, new Object[] {n11CategoryId, A11CategoryId});
         RcdFound4 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound4 = 1;
            A11CategoryId = BC000410_A11CategoryId[0];
            n11CategoryId = BC000410_n11CategoryId[0];
            A12CategoryName = BC000410_A12CategoryName[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext044( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound4 = 0;
         ScanKeyLoad044( ) ;
      }

      protected void ScanKeyLoad044( )
      {
         sMode4 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound4 = 1;
            A11CategoryId = BC000410_A11CategoryId[0];
            n11CategoryId = BC000410_n11CategoryId[0];
            A12CategoryName = BC000410_A12CategoryName[0];
         }
         Gx_mode = sMode4;
      }

      protected void ScanKeyEnd044( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm044( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert044( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate044( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete044( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete044( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate044( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes044( )
      {
      }

      protected void send_integrity_lvl_hashes044( )
      {
      }

      protected void AddRow044( )
      {
         VarsToRow4( bcCategory) ;
      }

      protected void ReadRow044( )
      {
         RowToVars4( bcCategory, 1) ;
      }

      protected void InitializeNonKey044( )
      {
         A12CategoryName = "";
         Z12CategoryName = "";
      }

      protected void InitAll044( )
      {
         A11CategoryId = 0;
         n11CategoryId = false;
         InitializeNonKey044( ) ;
      }

      protected void StandaloneModalInsert( )
      {
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

      public void VarsToRow4( SdtCategory obj4 )
      {
         obj4.gxTpr_Mode = Gx_mode;
         obj4.gxTpr_Categoryname = A12CategoryName;
         obj4.gxTpr_Categoryid = A11CategoryId;
         obj4.gxTpr_Categoryid_Z = Z11CategoryId;
         obj4.gxTpr_Categoryname_Z = Z12CategoryName;
         obj4.gxTpr_Categoryid_N = (short)(Convert.ToInt16(n11CategoryId));
         obj4.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow4( SdtCategory obj4 )
      {
         obj4.gxTpr_Categoryid = A11CategoryId;
         return  ;
      }

      public void RowToVars4( SdtCategory obj4 ,
                              int forceLoad )
      {
         Gx_mode = obj4.gxTpr_Mode;
         A12CategoryName = obj4.gxTpr_Categoryname;
         A11CategoryId = obj4.gxTpr_Categoryid;
         n11CategoryId = false;
         Z11CategoryId = obj4.gxTpr_Categoryid_Z;
         Z12CategoryName = obj4.gxTpr_Categoryname_Z;
         n11CategoryId = (bool)(Convert.ToBoolean(obj4.gxTpr_Categoryid_N));
         Gx_mode = obj4.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A11CategoryId = (short)getParm(obj,0);
         n11CategoryId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey044( ) ;
         ScanKeyStart044( ) ;
         if ( RcdFound4 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z11CategoryId = A11CategoryId;
         }
         ZM044( -1) ;
         OnLoadActions044( ) ;
         AddRow044( ) ;
         ScanKeyEnd044( ) ;
         if ( RcdFound4 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      public void Load( )
      {
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         RowToVars4( bcCategory, 0) ;
         ScanKeyStart044( ) ;
         if ( RcdFound4 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z11CategoryId = A11CategoryId;
         }
         ZM044( -1) ;
         OnLoadActions044( ) ;
         AddRow044( ) ;
         ScanKeyEnd044( ) ;
         if ( RcdFound4 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey044( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert044( ) ;
         }
         else
         {
            if ( RcdFound4 == 1 )
            {
               if ( A11CategoryId != Z11CategoryId )
               {
                  A11CategoryId = Z11CategoryId;
                  n11CategoryId = false;
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  Update044( ) ;
               }
            }
            else
            {
               if ( IsDlt( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else
               {
                  if ( A11CategoryId != Z11CategoryId )
                  {
                     if ( IsUpd( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert044( ) ;
                     }
                  }
                  else
                  {
                     if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert044( ) ;
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      public void Save( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars4( bcCategory, 1) ;
         SaveImpl( ) ;
         VarsToRow4( bcCategory) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars4( bcCategory, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert044( ) ;
         AfterTrn( ) ;
         VarsToRow4( bcCategory) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow4( bcCategory) ;
         }
         else
         {
            SdtCategory auxBC = new SdtCategory(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A11CategoryId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcCategory);
               auxBC.Save();
               bcCategory.Copy((GxSilentTrnSdt)(auxBC));
            }
            LclMsgLst = (msglist)(auxTrn.GetMessages());
            AnyError = (short)(auxTrn.Errors());
            context.GX_msglist = LclMsgLst;
            if ( auxTrn.Errors() == 0 )
            {
               Gx_mode = auxTrn.GetMode();
               AfterTrn( ) ;
            }
         }
      }

      public bool Update( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars4( bcCategory, 1) ;
         UpdateImpl( ) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public bool InsertOrUpdate( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars4( bcCategory, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert044( ) ;
         if ( AnyError == 1 )
         {
            if ( StringUtil.StrCmp(context.GX_msglist.getItemValue(1), "DuplicatePrimaryKey") == 0 )
            {
               AnyError = 0;
               context.GX_msglist.removeAllItems();
               UpdateImpl( ) ;
            }
            else
            {
               VarsToRow4( bcCategory) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow4( bcCategory) ;
         }
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars4( bcCategory, 0) ;
         GetKey044( ) ;
         if ( RcdFound4 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A11CategoryId != Z11CategoryId )
            {
               A11CategoryId = Z11CategoryId;
               n11CategoryId = false;
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( IsDlt( ) )
            {
               delete_Check( ) ;
            }
            else
            {
               Gx_mode = "UPD";
               update_Check( ) ;
            }
         }
         else
         {
            if ( A11CategoryId != Z11CategoryId )
            {
               Gx_mode = "INS";
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                  AnyError = 1;
               }
               else
               {
                  Gx_mode = "INS";
                  insert_Check( ) ;
               }
            }
         }
         pr_default.close(1);
         context.RollbackDataStores("category_bc",pr_default);
         VarsToRow4( bcCategory) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public int Errors( )
      {
         if ( AnyError == 0 )
         {
            return (int)(0) ;
         }
         return (int)(1) ;
      }

      public msglist GetMessages( )
      {
         return LclMsgLst ;
      }

      public string GetMode( )
      {
         Gx_mode = bcCategory.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcCategory.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcCategory )
         {
            bcCategory = (SdtCategory)(sdt);
            if ( StringUtil.StrCmp(bcCategory.gxTpr_Mode, "") == 0 )
            {
               bcCategory.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow4( bcCategory) ;
            }
            else
            {
               RowToVars4( bcCategory, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcCategory.gxTpr_Mode, "") == 0 )
            {
               bcCategory.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars4( bcCategory, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtCategory Category_BC
      {
         get {
            return bcCategory ;
         }

      }

      public void webExecute( )
      {
         createObjects();
         initialize();
      }

      public bool isMasterPage( )
      {
         return false;
      }

      protected void createObjects( )
      {
      }

      protected void Process( )
      {
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
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z12CategoryName = "";
         A12CategoryName = "";
         BC00044_A11CategoryId = new short[1] ;
         BC00044_n11CategoryId = new bool[] {false} ;
         BC00044_A12CategoryName = new string[] {""} ;
         BC00045_A11CategoryId = new short[1] ;
         BC00045_n11CategoryId = new bool[] {false} ;
         BC00043_A11CategoryId = new short[1] ;
         BC00043_n11CategoryId = new bool[] {false} ;
         BC00043_A12CategoryName = new string[] {""} ;
         sMode4 = "";
         BC00042_A11CategoryId = new short[1] ;
         BC00042_n11CategoryId = new bool[] {false} ;
         BC00042_A12CategoryName = new string[] {""} ;
         BC00046_A11CategoryId = new short[1] ;
         BC00046_n11CategoryId = new bool[] {false} ;
         BC00049_A7AttractionId = new short[1] ;
         BC000410_A11CategoryId = new short[1] ;
         BC000410_n11CategoryId = new bool[] {false} ;
         BC000410_A12CategoryName = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.category_bc__default(),
            new Object[][] {
                new Object[] {
               BC00042_A11CategoryId, BC00042_A12CategoryName
               }
               , new Object[] {
               BC00043_A11CategoryId, BC00043_A12CategoryName
               }
               , new Object[] {
               BC00044_A11CategoryId, BC00044_A12CategoryName
               }
               , new Object[] {
               BC00045_A11CategoryId
               }
               , new Object[] {
               BC00046_A11CategoryId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC00049_A7AttractionId
               }
               , new Object[] {
               BC000410_A11CategoryId, BC000410_A12CategoryName
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z11CategoryId ;
      private short A11CategoryId ;
      private short RcdFound4 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z12CategoryName ;
      private string A12CategoryName ;
      private string sMode4 ;
      private bool n11CategoryId ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] BC00044_A11CategoryId ;
      private bool[] BC00044_n11CategoryId ;
      private string[] BC00044_A12CategoryName ;
      private short[] BC00045_A11CategoryId ;
      private bool[] BC00045_n11CategoryId ;
      private short[] BC00043_A11CategoryId ;
      private bool[] BC00043_n11CategoryId ;
      private string[] BC00043_A12CategoryName ;
      private short[] BC00042_A11CategoryId ;
      private bool[] BC00042_n11CategoryId ;
      private string[] BC00042_A12CategoryName ;
      private short[] BC00046_A11CategoryId ;
      private bool[] BC00046_n11CategoryId ;
      private short[] BC00049_A7AttractionId ;
      private short[] BC000410_A11CategoryId ;
      private bool[] BC000410_n11CategoryId ;
      private string[] BC000410_A12CategoryName ;
      private SdtCategory bcCategory ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class category_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[5])
         ,new UpdateCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00042;
          prmBC00042 = new Object[] {
          new ParDef("@CategoryId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC00043;
          prmBC00043 = new Object[] {
          new ParDef("@CategoryId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC00044;
          prmBC00044 = new Object[] {
          new ParDef("@CategoryId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC00045;
          prmBC00045 = new Object[] {
          new ParDef("@CategoryId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC00046;
          prmBC00046 = new Object[] {
          new ParDef("@CategoryName",GXType.NChar,50,0)
          };
          Object[] prmBC00047;
          prmBC00047 = new Object[] {
          new ParDef("@CategoryName",GXType.NChar,50,0) ,
          new ParDef("@CategoryId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC00048;
          prmBC00048 = new Object[] {
          new ParDef("@CategoryId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC00049;
          prmBC00049 = new Object[] {
          new ParDef("@CategoryId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000410;
          prmBC000410 = new Object[] {
          new ParDef("@CategoryId",GXType.Int16,4,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("BC00042", "SELECT [CategoryId], [CategoryName] FROM [Category] WITH (UPDLOCK) WHERE [CategoryId] = @CategoryId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00042,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00043", "SELECT [CategoryId], [CategoryName] FROM [Category] WHERE [CategoryId] = @CategoryId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00043,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00044", "SELECT TM1.[CategoryId], TM1.[CategoryName] FROM [Category] TM1 WHERE TM1.[CategoryId] = @CategoryId ORDER BY TM1.[CategoryId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00044,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00045", "SELECT [CategoryId] FROM [Category] WHERE [CategoryId] = @CategoryId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00045,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00046", "INSERT INTO [Category]([CategoryName]) VALUES(@CategoryName); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC00046,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC00047", "UPDATE [Category] SET [CategoryName]=@CategoryName  WHERE [CategoryId] = @CategoryId", GxErrorMask.GX_NOMASK,prmBC00047)
             ,new CursorDef("BC00048", "DELETE FROM [Category]  WHERE [CategoryId] = @CategoryId", GxErrorMask.GX_NOMASK,prmBC00048)
             ,new CursorDef("BC00049", "SELECT TOP 1 [AttractionId] FROM [Attractions] WHERE [CategoryId] = @CategoryId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00049,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000410", "SELECT TM1.[CategoryId], TM1.[CategoryName] FROM [Category] TM1 WHERE TM1.[CategoryId] = @CategoryId ORDER BY TM1.[CategoryId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000410,100, GxCacheFrequency.OFF ,true,false )
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
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                return;
       }
    }

 }

}
