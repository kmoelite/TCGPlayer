using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TCGPlayerKevinMohan.Models;

namespace TCGPlayerKevinMohan.Repositories
{
    public class MagicCardsRepository
    {
        public IEnumerable<MagicCard> GetCardsInitialSearchStoredProc(string searchText)
        {
            var magicCardsResult = new List<MagicCard>();

            using (var magicCardContext = new MagicCardContext())
            {
                SqlParameter searchTextSqlParam = new SqlParameter("@SearchText", searchText);
                magicCardsResult = magicCardContext.Database.SqlQuery<MagicCard>("EXEC [dbo].[GetCardsInitialSearch] @searchText=@SearchText", searchTextSqlParam).ToList();
            }

            return magicCardsResult;
        }

        public Set GetSetInfoBySetId(int setId)
        {
            var setResult = new Set();

            using (var magicCardContext = new MagicCardContext())
            {
                SqlParameter setSearchParam = new SqlParameter("@setId", setId);
                setResult = magicCardContext.Database.SqlQuery<Set>("SELECT * FROM [TCG].[Cards].[Set] WHERE SetId = @setId", setSearchParam).FirstOrDefault();
            }

            return setResult;
        }

        public Rarity GetRarityInfoByRarityId(int rarityId)
        {
            var rarityResult = new Rarity();

            using (var magicCardContext = new MagicCardContext())
            {
                SqlParameter raritySearchParam = new SqlParameter("@rarityId", rarityId);
                rarityResult = magicCardContext.Database.SqlQuery<Rarity>("SELECT * FROM [TCG].[Cards].[Rarity] WHERE RarityId = @rarityId", raritySearchParam).FirstOrDefault();
            }

            return rarityResult;
        }

        public void LogDBChange(MagicCard card)
        {
            using (var magicCardContext = new MagicCardContext())
            {
                var sqlParams = new List<SqlParameter>();
                sqlParams.Add(new SqlParameter("@updatedAccessPath", card.AccessPath));
                sqlParams.Add(new SqlParameter("@cardId", card.CardId));
                sqlParams.Add(new SqlParameter("@updatedCardName", card.CardName));
                sqlParams.Add(new SqlParameter("@updatedCardText", card.CardText));
                sqlParams.Add(new SqlParameter("@updatedNumber", card.Number));
                sqlParams.Add(new SqlParameter("@updatedPrice", card.Price));
                sqlParams.Add(new SqlParameter("@updatedQuantity", card.Quantity));
                sqlParams.Add(new SqlParameter("@updatedRarityId", card.RarityId));
                sqlParams.Add(new SqlParameter("@updatedSetId", card.SetId));
                magicCardContext.Database.ExecuteSqlCommand("INSERT INTO [TCG].[Cards].[CardLog]"
                + " ([CardId],[UpdatedCardName],[UpdatedCardText],[UpdatedNumber],[UpdatedSetId],[UpdatedRarityId],[UpdatedPrice],[UpdatedQuantity],[UpdatedAccessPath],[UpdatedTime])"
                + " VALUES"
                + " (@cardId, @updatedCardName, @updatedCardText, @updatedNumber, @updatedSetId, @updatedRarityId, @updatedPrice, @updatedQuantity, @updatedAccessPath, GETDATE())", sqlParams.ToArray());
            }
        }
    }
}