using DevExpress.Xpo;
using ListOfVatTaxpayers.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListOfVatTaxpayers.Module.Helpers
{
    class ObjectsConverter
    {
        public static void EntityPersonTableConverter(Models.EntityPerson[] mEntityPeoples, XPCollection<EntityPerson> entityPeoples, Session session)
        {
            if (mEntityPeoples == null)
                return;
            session.Delete(entityPeoples);
            EntityPerson[] entityPeople = new EntityPerson[mEntityPeoples.Length];

            for (int i = 0; i < mEntityPeoples.Length; i++)
            {
                entityPeople[i] = new EntityPerson(session);
                entityPeople[i].CompanyName = mEntityPeoples[i].CompanyName;
                entityPeople[i].FirstName = mEntityPeoples[i].FirstName;
                entityPeople[i].LastName = mEntityPeoples[i].LastName;
                entityPeople[i].Pesel = mEntityPeoples[i].Pesel;
                entityPeople[i].Nip = mEntityPeoples[i].Nip;

                entityPeoples.Add(entityPeople[i]);
            }
        }

        public static void EntityTableConverter(Models.Entity[] mEntity, XPCollection<Entity> entities, Session session)
        {
            if (mEntity == null)
                return;

            Entity[] entity = new Entity[mEntity.Length];

            for (int i = 0; i < mEntity.Length; i++)
            {
                entity[i] = new Entity(session);
                EntityConverter(mEntity[i], entity[i], session);
                entities.Add(entity[i]);
            }
        }

        public static void EntryTableConverter(Models.Entry[] mEntries, XPCollection<Entry> entries, Session session)
        {
            if (mEntries == null)
                return;

            session.Delete(entries);

            Entry[] entry = new Entry[mEntries.Length];

            for (int i = 0; i < mEntries.Length; i++)
            {
                entry[i] = new Entry(session);
                EntityTableConverter(mEntries[i].Subjects, entry[i].Entities, session);
                entries.Add(entry[i]);
            }
        }

        public static void EntityConverter(Models.Entity mEntity, Entity entity, Session session)
        {
            if (mEntity == null)
                return;

            entity.Name = mEntity.Name;
            entity.Nip = mEntity.Nip;
            entity.StatusVat = (StatusVat)mEntity.StatusVat;
            entity.Regon = mEntity.Regon;
            entity.Pesel = mEntity.Pesel;
            entity.Krs = mEntity.KRS;
            entity.ResidenceAddress = mEntity.ResidenceAddress;
            entity.WorkingAddress = mEntity.WorkingAddress;
            ObjectsConverter.EntityPersonTableConverter(mEntity.Representatives, entity.Representatives, session);
            ObjectsConverter.EntityPersonTableConverter(mEntity.AuthorizedClerks, entity.AuthorizedClerks, session);
             ObjectsConverter.EntityPersonTableConverter(mEntity.Partners, entity.Partners, session);
            entity.RegistrationLegalDate = mEntity.RegistrationLegalDate;
            entity.RegistrationDenialDate = mEntity.RegistrationDenialDate;
            entity.RegistrationDenialBasis = mEntity.RegistrationDenialBasis;
            entity.RestorationDate = mEntity.RestorationDate;
            entity.RestorationBasis = mEntity.RestorationBasis;
            entity.RemovalDate = mEntity.RemovalDate;
            entity.RemovalBasis = mEntity.RemovalBasis;
            entity.HasVirtualAccounts = mEntity.HasVirtualAccounts;
            Value[] values = new Value[mEntity.AccountNumbers.Length];
            session.Delete(entity.AccountNumbers);
                for (int i = 0; i < mEntity.AccountNumbers.Length; i++)
                {
                    values[i] = new Value(session);
                    values[i].Field = mEntity.AccountNumbers[i];
                    entity.AccountNumbers.Add(values[i]);
                }
        }

        public static void EntityCheckConverter(Models.EntityCheck mEntityCheck, EntityCheck entityCheck)
        {
            entityCheck.AccountAssigned = mEntityCheck.AccountAssigned;
            entityCheck.RequestDateTime = mEntityCheck.RequestDateTime;
            entityCheck.RequestId = mEntityCheck.RequestId;
        }
    }
}
