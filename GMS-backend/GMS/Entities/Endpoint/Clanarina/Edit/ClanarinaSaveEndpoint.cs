﻿using GMS.Data;
using GMS.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GMS.Entities.Endpoint.Clanarina.Save
{

    [Route("Clanarina-Edit")]
    public class ClanarineSaveEndpoint : MyBaseEndpoint<ClanarinaSaveRequest, int>
    {
        private readonly ApplicationDbContext db;

        public ClanarineSaveEndpoint(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpPost]
        public override async Task<int> Handle([FromBody] ClanarinaSaveRequest request, CancellationToken cancellationToken)
        {
            Models.Clanarina? clanarina;
            if (request.ID == 0)
            {
                clanarina = new Models.Clanarina();
                db.Add(clanarina);


            }
            else
            {
                clanarina = db.Clanarina.FirstOrDefault(s => s.ID == request.ID);
                if (clanarina == null)
                    throw new Exception("pogresan ID");
            }

            clanarina.Naziv = request.Naziv.RemoveTags();
            clanarina.Cijena = request.Cijena;
            clanarina.Opis = request.Opis.RemoveTags();
            


            await db.SaveChangesAsync(cancellationToken);

            return clanarina.ID;
        }
    }
}

