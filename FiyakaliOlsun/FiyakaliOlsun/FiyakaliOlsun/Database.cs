using FiyakaliOlsun.Models;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FiyakaliOlsun
{
    public static class Database
    {
        private static ISessionFactory _sessionFactory;
        private const string SessionKey = "fiyakaliolsun.Database.SessionKey";

        public static ISession Session
        {
            get { return (ISession)HttpContext.Current.Items[SessionKey]; }
        }
        public static void Configure() //yeni yaratılan configuration yaratıldığında web.configden yapılandırma ayarlarına bakacaktır.
        {

            var config = new Configuration();
            config.Configure();

            //add mappings

            var mapper = new ModelMapper();
            mapper.AddMapping<UrunlerMap>();
            mapper.AddMapping<SepetMap>();
            mapper.AddMapping<MusteriMap>();
            mapper.AddMapping<AdminKullaniciMap>();

            config.AddMapping(mapper.CompileMappingForAllExplicitlyAddedEntities());

            _sessionFactory = config.BuildSessionFactory();
        }

        public static void OpenSession()
        {
            HttpContext.Current.Items[SessionKey] = _sessionFactory.OpenSession();
        }

        public static void CloseSession()
        {
            var session = HttpContext.Current.Items[SessionKey] as ISession;
            if (session != null)
            {
                session.Close();
            }
            HttpContext.Current.Items.Remove(SessionKey); //tekrar silindi.
        }
    }
}