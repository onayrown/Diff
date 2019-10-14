using DiffedData.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiffedData.Api.DTOs
{
    public class DiffDto
    {
        public string Content { get; set; }

        internal DataCommand ToLeftCommand(string id) =>
             new DataCommand(id, Content, "left");

        internal DataCommand ToRightCommand(string id) =>
            new DataCommand(id, Content, "right");
    }
}
