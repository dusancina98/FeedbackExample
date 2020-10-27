using System;
using System.Collections.Generic;
using System.Text;

namespace FeedbackExample.Contracts.IdentifiableDTO
{
    //Ova klasa se koristi da bi klasama iz DTO foldera dodali Id kada se vraca na klijent
    //Mozda glupo deluje jer kada se spoje DTO i Id dobije se Entitet iz Modela
    // ali u vasem programu ce biti npr password kod Usera koji nikad ne treba da se prosledjuje kod klijenta
    // mozda je overkill sad, pa slobodno javite sta mislite o ovom nacinu rada
    public class IdentifiableDTO<T> where T : class
    {
        public Guid Id { get; set; }

        public T EntityDTO { get; set; }
    }
}
