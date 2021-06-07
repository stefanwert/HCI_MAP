using System;
using System.Collections.Generic;
using System.Text;
using HCI_MAP.Repository;
using HCI_MAP.Model;

namespace HCI_MAP.Service
{
    public class TypeOfEventService
    {
        private TypeOfEventRepository typeOfEventRepository = new TypeOfEventRepository();

        public List<TypeOfEvent> GetAllTypeOfEvent()
        {
            return typeOfEventRepository.GetAllTypeOfEvent();
        }
        public TypeOfEvent AddTypeOfEvent(TypeOfEvent typeOfEvent)
        {
            return typeOfEventRepository.AddTypeOfEvent(typeOfEvent);
        }

        public bool RemoveTypeOfEvent(TypeOfEvent typeOfEvent)
        {
            return typeOfEventRepository.RemoveTypeOfEvent(typeOfEvent);
        }

        public TypeOfEvent EditTypeOfEvent(TypeOfEvent typeOfEvent)
        {
            return typeOfEventRepository.EditTypeOfEvent(typeOfEvent);
        }

        public TypeOfEvent getById(int id)
        {
            return typeOfEventRepository.getById(id);
        }
    }
}
