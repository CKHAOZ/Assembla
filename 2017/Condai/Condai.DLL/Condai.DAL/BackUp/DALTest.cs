using System;
using System.Collections.Generic;
using Condai.Entity;
using System.Linq.Expressions;

namespace Condai.DAL
{
    public class DALTest
    {
        private static DALTest obj = new DALTest();

        public static DALTest Instance
        {
            get { return obj; }
        }
                
        public int AddDAL(Condai.Entity.Login_Inquietud add)
        {
            RepositorioTest<Condai.Entity.Login_Inquietud> contexto = new RepositorioTest<Condai.Entity.Login_Inquietud>();

            return contexto.InsertarObjeto(add);
        }
    }
}
