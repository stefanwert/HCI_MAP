using HCI_MAP.Service;
using System;
using System.Collections.Generic;
using System.Text;
using HCI_MAP.Model;

namespace HCI_MAP.Controller
{
    public class TypeOfEventController
    {
        private TypeOfEventService typeOfEventService = new TypeOfEventService();

        public List<TypeOfEvent> GetAllTypeOfEvent()
        {
            return typeOfEventService.GetAllTypeOfEvent();
        }

        public TypeOfEvent AddTypeOfEvent(TypeOfEvent typeOfEvent)
        {
            return typeOfEventService.AddTypeOfEvent(typeOfEvent);
        }
        public bool RemoveTypeOfEvent(TypeOfEvent typeOfEvent)
        {
            return typeOfEventService.RemoveTypeOfEvent(typeOfEvent);
        }

        public TypeOfEvent EditTypeOfEvent(TypeOfEvent typeOfEvent)
        {
            return typeOfEventService.EditTypeOfEvent(typeOfEvent);
        }

        public TypeOfEvent getById(int id)
        {
            return typeOfEventService.getById(id);
        }
    }
}
