using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RGC.BusinessEntitiesLayer;
using System.Data;
using System.Web;
using System.Xml.Linq;

namespace RGC.BusinessLogicLayer
{
    public class BLLAdjuntos : BLLBaseClass
    {
        #region [ ATTRIBUTES ]

        private static BLLAdjuntos obj = new BLLAdjuntos();
        private const string POLICITYNAME = "BusinessExceptionPolicy";

        #endregion

        #region [ PROPERTIES ]

        public static BLLAdjuntos Instance
        {
            get { return obj; }
        }

        #endregion

        #region [ CONSTRUCTOR ]

        public BLLAdjuntos() { }

        #endregion

        #region [ METHODS ]
        public TransactionResult<List<EntityAdjuntos>> Select(string name)
        {
            return Select(null, null, null, null, null, name, false, null, null);
        }

        public TransactionResult<List<EntityAdjuntos>> Select(int AttachOf_Id)
        {
            return Select(null, AttachOf_Id, null, null, null, false);
        }

        public TransactionResult<List<EntityAdjuntos>> Select(int AttachOf_Id, bool mirror)
        {
            return Select(null, AttachOf_Id, null, null, null, mirror);
        }

        public TransactionResult<List<EntityAdjuntos>> Select(int? Id, int? AttachOf_Id, string AttachOf_Name, int? Status, string Tipo)
        {
            return Select(Id, AttachOf_Id, AttachOf_Name, Status, Tipo, null, false, null, null);
        }

        public TransactionResult<List<EntityAdjuntos>> Select(string name, bool mirror)
        {
            return Select(null, null, null, null, null, name, mirror, null, null);
        }

        public TransactionResult<List<EntityAdjuntos>> Select(int? Id, int? AttachOf_Id, string AttachOf_Name, int? Status, string Tipo, bool mirror)
        {
            return Select(Id, AttachOf_Id, AttachOf_Name, Status, Tipo, null, mirror, null, null);
        }

        public TransactionResult<List<EntityAdjuntos>> Select(int? Id, int? AttachOf_Id, string AttachOf_Name, int? Status, string Tipo, string name, bool mirror, string description, string description_Like)
        {
            Func<XDocument, List<EntityAdjuntos>> CustomFunction = xDoc =>
            {
                List<EntityAdjuntos> lstAtt = new List<EntityAdjuntos>();

                if (xDoc.Descendants("row").Count() > 0)
                {
                    lstAtt = (from x in xDoc.Descendants("row")
                              select new EntityAdjuntos
                              {
                                  ID = (int)x.Attribute("ID"),
                                  Path = (string)x.Attribute("PATH"),
                                  Type = (string)x.Attribute("TYPE"),
                                  Name = (string)x.Attribute("NAME"),
                                  AttachOfId = (int)x.Attribute("ATTACHOF_ID"),
                                  AttachOfName = (string)x.Attribute("ATTACHOF_NAME"),
                                  User = (string)x.Attribute("USER_ID"),
                                  Description = (string)x.Attribute("DESCRIPTION"),
                                  Status = (int)x.Attribute("STATUS"),
                                  Source = (x.Attributes("SOURCE").Count() > 0 ? x.Attribute("SOURCE").Value : null),
                                  par_id_ObS = (string)x.Attribute("par_id_ObS"),
                                  par_cod_ObS = (string)x.Attribute("par_cod_ObS"),
                                  Fecha_Envio_Soporte = (x.Attributes("Fecha_Envio_Soporte").Count() > 0 ? new Nullable<DateTime>(Convert.ToDateTime(x.Attribute("Fecha_Envio_Soporte").Value)) : null),
                                  ATTACH_DATE = (x.Attributes("ATTACH_DATE").Count() > 0 ? new Nullable<DateTime>(Convert.ToDateTime(x.Attribute("ATTACH_DATE").Value)) : null),
                                  Emp_Numero = (x.Attributes("Emp_Numero").Count() > 0 ? x.Attribute("Emp_Numero").Value.ToNullableInt32() : null),
                                  De_Quien = (x.Attributes("De_Quien").Count() > 0 ? x.Attribute("De_Quien").Value.ToNullableInt32() : null),
                                  Comentario_Ultimo_Auditor = (x.Attributes("COMMENTS_AUDIT").Count() > 0 ? x.Attribute("COMMENTS_AUDIT").Value.ToString() : null)
                              }).ToList();
                }

                return lstAtt;
            };

            return GetAbstractData<List<EntityAdjuntos>>(string.Concat("SPNET_ADJUNTOS_SHOW", (mirror ? "_Mirror" : string.Empty)), new DataService.ServiceSpParameter[]
                {
                    new DataService.ServiceSpParameter() { ParameterName = "@ID", ParameterValue = Id, ParameterType = System.Data.SqlDbType.Int },
                    new DataService.ServiceSpParameter() { ParameterName = "@ATTACHOF_ID", ParameterValue = AttachOf_Id, ParameterType = System.Data.SqlDbType.Int },
                    new DataService.ServiceSpParameter() { ParameterName = "@ATTACHOF_NAME", ParameterValue = AttachOf_Name, ParameterType = System.Data.SqlDbType.VarChar },
                    new DataService.ServiceSpParameter() { ParameterName = "@STATUS", ParameterValue = Status, ParameterType = System.Data.SqlDbType.Int },
                    new DataService.ServiceSpParameter() { ParameterName = "@TYPE", ParameterValue = Tipo, ParameterType = System.Data.SqlDbType.VarChar },
                    new DataService.ServiceSpParameter() { ParameterName = "@NAME", ParameterValue = name, ParameterType = System.Data.SqlDbType.VarChar },
                    new DataService.ServiceSpParameter() { ParameterName = "@DESCRIPTION", ParameterValue = description, ParameterType = System.Data.SqlDbType.VarChar },
                    new DataService.ServiceSpParameter() { ParameterName = "@DESCRIPTION_LIKE", ParameterValue = description_Like, ParameterType = System.Data.SqlDbType.VarChar }
                }, CustomFunction);
        }

        public TransactionResult<List<EntityAdjuntos>> SelectAttachmentTraza(int AttachOf_Id, int? Status)
        {
            Func<XDocument, List<EntityAdjuntos>> CustomFunction = xDoc =>
            {
                List<EntityAdjuntos> lstAtt = new List<EntityAdjuntos>();

                if (xDoc.Descendants("row").Count() > 0)
                {
                    lstAtt = (from x in xDoc.Descendants("row")
                              select new EntityAdjuntos
                              {
                                  ID = (int)x.Attribute("ID"),
                                  Path = (string)x.Attribute("PATH"),
                                  Type = (string)x.Attribute("TYPE"),
                                  Name = (string)x.Attribute("NAME"),
                                  AttachOfId = (int)x.Attribute("ATTACHOF_ID"),
                                  AttachOfName = (string)x.Attribute("ATTACHOF_NAME"),
                                  User = (string)x.Attribute("USER_ID"),
                                  Description = (string)x.Attribute("DESCRIPTION"),
                                  Status = (int)x.Attribute("STATUS"),
                                  Source = (x.Attributes("SOURCE").Count() > 0 ? x.Attribute("SOURCE").Value : null),
                              }).ToList();
                }
                return lstAtt;
            };

            return GetAbstractData<List<EntityAdjuntos>>("SPNET_ADJUNTOS_SHOW_TRAZA_FACTURA", new DataService.ServiceSpParameter[]
                {                    
                    new DataService.ServiceSpParameter() { ParameterName = "@ATTACHOF_ID", ParameterValue = AttachOf_Id, ParameterType = System.Data.SqlDbType.Int },                    
                    new DataService.ServiceSpParameter() { ParameterName = "@STATUS", ParameterValue = Status, ParameterType = System.Data.SqlDbType.Int },                                        
                }, CustomFunction);
        }



        public TransactionResult<int> NewAttachment(EntityAdjuntos Attach)
        {
            return NewAttachment(Attach, false);
        }

        public TransactionResult<int> NewAttachment(EntityAdjuntos Attach, bool mirror)
        {
            return ExecuteNonQuery(string.Concat("SPNET_ADJUNTOS_INS_UPD", (mirror ? "_Mirror" : string.Empty)), new DataService.ServiceSpParameter[]
                {
                    new DataService.ServiceSpParameter() { ParameterName = "@PATH", ParameterValue = Attach.Path, ParameterType = System.Data.SqlDbType.VarChar },
                    new DataService.ServiceSpParameter() { ParameterName = "@TYPE", ParameterValue = Attach.Type, ParameterType = System.Data.SqlDbType.VarChar },
                    new DataService.ServiceSpParameter() { ParameterName = "@NAME", ParameterValue = Attach.Name, ParameterType = System.Data.SqlDbType.VarChar },
                    new DataService.ServiceSpParameter() { ParameterName = "@ATTACHOF_ID", ParameterValue = Attach.AttachOfId, ParameterType = System.Data.SqlDbType.Int },
                    new DataService.ServiceSpParameter() { ParameterName = "@ATTACHOF_NAME", ParameterValue = Attach.AttachOfName, ParameterType = System.Data.SqlDbType.VarChar },
                    new DataService.ServiceSpParameter() { ParameterName = "@USER", ParameterValue = Attach.User, ParameterType = System.Data.SqlDbType.VarChar },
                    new DataService.ServiceSpParameter() { ParameterName = "@DESCRIPTION", ParameterValue = Attach.Description, ParameterType = System.Data.SqlDbType.VarChar },
                    new DataService.ServiceSpParameter() { ParameterName = "@STATUS", ParameterValue = Attach.Status, ParameterType = System.Data.SqlDbType.Int },
                    new DataService.ServiceSpParameter() { ParameterName = "@SOURCE", ParameterValue = Attach.Source, ParameterType = System.Data.SqlDbType.VarChar },
                    new DataService.ServiceSpParameter() { ParameterName = "@par_id_ObS", ParameterValue = Attach.par_id_ObS, ParameterType = System.Data.SqlDbType.VarChar },
                    new DataService.ServiceSpParameter() { ParameterName = "@par_cod_ObS", ParameterValue = Attach.par_cod_ObS, ParameterType = System.Data.SqlDbType.VarChar },
                    new DataService.ServiceSpParameter() { ParameterName = "@Fecha_Envio_Soporte", ParameterValue = Attach.Fecha_Envio_Soporte, ParameterType = System.Data.SqlDbType.DateTime },
                    new DataService.ServiceSpParameter() { ParameterName = "@Emp_Numero", ParameterValue = Attach.Emp_Numero, ParameterType = System.Data.SqlDbType.Int },
                    new DataService.ServiceSpParameter() { ParameterName = "@De_Quien", ParameterValue = Attach.De_Quien, ParameterType = System.Data.SqlDbType.Int}
                });
        }

        public TransactionResult<int> EditAttachment(EntityAdjuntos Attach)
        {
            return EditAttachment(Attach, false);
        }

        public TransactionResult<int> EditAttachment(EntityAdjuntos Attach, bool mirror)
        {
            return ExecuteNonQuery(String.Concat("SPNET_ADJUNTOS_INS_UPD", (mirror ? "_Mirror" : String.Empty)), new DataService.ServiceSpParameter[]
                {
                    new DataService.ServiceSpParameter() { ParameterName = "@ID", ParameterValue = Attach.ID, ParameterType = System.Data.SqlDbType.Int },
                    new DataService.ServiceSpParameter() { ParameterName = "@PATH", ParameterValue = Attach.Path, ParameterType = System.Data.SqlDbType.VarChar },
                    new DataService.ServiceSpParameter() { ParameterName = "@TYPE", ParameterValue = Attach.Type, ParameterType = System.Data.SqlDbType.VarChar },
                    new DataService.ServiceSpParameter() { ParameterName = "@NAME", ParameterValue = Attach.Name, ParameterType = System.Data.SqlDbType.VarChar },
                    new DataService.ServiceSpParameter() { ParameterName = "@ATTACHOF_ID", ParameterValue = Attach.AttachOfId, ParameterType = System.Data.SqlDbType.Int },
                    new DataService.ServiceSpParameter() { ParameterName = "@ATTACHOF_NAME", ParameterValue = Attach.AttachOfName, ParameterType = System.Data.SqlDbType.VarChar },
                    new DataService.ServiceSpParameter() { ParameterName = "@USER", ParameterValue = Attach.User, ParameterType = System.Data.SqlDbType.VarChar },
                    new DataService.ServiceSpParameter() { ParameterName = "@DESCRIPTION", ParameterValue = Attach.Description, ParameterType = System.Data.SqlDbType.VarChar },
                    new DataService.ServiceSpParameter() { ParameterName = "@STATUS", ParameterValue = Attach.Status, ParameterType = System.Data.SqlDbType.Int },
                    new DataService.ServiceSpParameter() { ParameterName = "@SOURCE", ParameterValue = Attach.Source, ParameterType = System.Data.SqlDbType.VarChar },
                    new DataService.ServiceSpParameter() { ParameterName = "@par_id_ObS", ParameterValue = Attach.par_id_ObS, ParameterType = System.Data.SqlDbType.VarChar },
                    new DataService.ServiceSpParameter() { ParameterName = "@par_cod_ObS", ParameterValue = Attach.par_cod_ObS, ParameterType = System.Data.SqlDbType.VarChar },
                    new DataService.ServiceSpParameter() { ParameterName = "@Fecha_Envio_Soporte", ParameterValue = Attach.Fecha_Envio_Soporte, ParameterType = System.Data.SqlDbType.DateTime },
                    new DataService.ServiceSpParameter() { ParameterName = "@Emp_Numero", ParameterValue = Attach.Emp_Numero, ParameterType = System.Data.SqlDbType.Int },
                    new DataService.ServiceSpParameter() { ParameterName = "@De_Quien", ParameterValue = Attach.De_Quien, ParameterType = System.Data.SqlDbType.Int},
                    new DataService.ServiceSpParameter() { ParameterName = "@CHECKSUM", ParameterValue = Attach.checksum, ParameterType = System.Data.SqlDbType.VarChar}
                });
        }
        public TransactionResult<int> DeleteAttachment(int? ID, int? AttachOf_Id, string AttachOf_Name, string user)
        {
            return ExecuteNonQuery("SPNET_ADJUNTOS_DEL", new DataService.ServiceSpParameter[]
                {
                    new DataService.ServiceSpParameter() { ParameterName = "@ID", ParameterValue = ID, ParameterType = System.Data.SqlDbType.Int },
                    new DataService.ServiceSpParameter() { ParameterName = "@ATTACHOF_ID", ParameterValue = AttachOf_Id, ParameterType = System.Data.SqlDbType.Int },
                    new DataService.ServiceSpParameter() { ParameterName = "@ATTACHOF_NAME", ParameterValue = AttachOf_Name, ParameterType = System.Data.SqlDbType.VarChar },
                    new DataService.ServiceSpParameter() { ParameterName = "@USER", ParameterValue = user, ParameterType = System.Data.SqlDbType.VarChar }
                });
        }

        public TransactionResult<int> ModificarAdjuntos_Status_Masivo(DataTable IDs, int nuevoEstado)
        {
            return ExecuteNonQuery("SPNET_ADJUNTOS_Masivo_x_Id_UPD", new DataService.ServiceSpParameter[]
                {
                    new DataService.ServiceSpParameter() { ParameterName = "@IDs", ParameterValue = IDs.ToXml(), ParameterType = System.Data.SqlDbType.Structured },
                    new DataService.ServiceSpParameter() { ParameterName = "@newStatus", ParameterValue = nuevoEstado, ParameterType = System.Data.SqlDbType.Int }
                    
                });

        }

        public TransactionResult<int> ModificarComentario(int idAdjunto, String comentario)
        {
            return ExecuteNonQuery("SPNET_ADJUNTOS_UPD_COMMENTS", new DataService.ServiceSpParameter[]
                {
                    new DataService.ServiceSpParameter() { ParameterName = "@ID", ParameterValue = idAdjunto, ParameterType = System.Data.SqlDbType.Int },
                    new DataService.ServiceSpParameter() { ParameterName = "@COMMENTS_AUDIT", ParameterValue = comentario, ParameterType = System.Data.SqlDbType.VarChar }
                    
                });
        }

        public TransactionResult<List<String>> verificarChecksums(int de_quien, int emp_numero, byte[] checksum, bool mirror)
        {
            Func<XDocument, List<String>> CustomFunction = xDoc =>
            {
                List<String> lstAtt = new List<String>();
                if (xDoc.Descendants("row").Count() > 0)
                {
                    foreach (var x in xDoc.Descendants("row"))
                    {
                        lstAtt.Add((string)x.Attribute("VALID"));
                        lstAtt.Add((string)x.Attribute("ID"));
                    }
                }
                return lstAtt;
            };
            return GetAbstractData<List<String>>("SPNET_VALIDA_CHECKSUMS_ADJUNTOS", new DataService.ServiceSpParameter[]
                {
                    new DataService.ServiceSpParameter() { ParameterName = "@de_quien", ParameterValue = de_quien, ParameterType = System.Data.SqlDbType.Int }, 
                    new DataService.ServiceSpParameter() { ParameterName = "@emp_numero", ParameterValue = emp_numero, ParameterType = System.Data.SqlDbType.Int }, 
                    new DataService.ServiceSpParameter() { ParameterName = "@CHECKSUM", ParameterValue =   Convert.ToString(BitConverter.ToString(checksum,2)).PadLeft(64,'0'), ParameterType = System.Data.SqlDbType.VarChar },      
                    //Para devolver se usa Array.Reverse(checksum).
                    new DataService.ServiceSpParameter() { ParameterName = "@mirror", ParameterValue = mirror ? "1" : "0", ParameterType = System.Data.SqlDbType.VarChar },
                }, CustomFunction);
        }


        #endregion
    }
}
