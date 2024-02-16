using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            var itemQualityDegradeAmount = 1;
            foreach (var item in Items)
            {
                // If "typical" item decrease item quality
                if (item.Name != "Aged Brie" 
                    && item.Name != "Backstage passes to a TAFKAL80ETC concert"
                    && item.Name != "Sulfuras, Hand of Ragnaros")
                {
                    if (item.Quality > 0)
                    {
                        item.Quality -= itemQualityDegradeAmount;
                    }
                }
                // if "non-typical" item (Aged brie, backstage pass, or Sulfuras)
                else
                {
                    if (item.Quality < 50)
                    {
                        // All non-typical items increase in quality by 1
                        var qualityAmountToIncrease = 1;

                        // Backstage pass quality increases variably as it approaches SellIn date
                        if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (item.SellIn < 6 && item.Quality < 50)
                            {
                                qualityAmountToIncrease = 3;
                            }
                            else if (item.SellIn < 11 && item.Quality < 50)
                            {
                                qualityAmountToIncrease = 2;
                            }
                        }
                        // Update non-typical item quality
                        item.Quality += qualityAmountToIncrease;
                    }
                }

                // Decrease SellIn date for all non-Sulfuras items
                if (item.Name != "Sulfuras, Hand of Ragnaros")
                {
                    item.SellIn -= 1;
                }
                // Decrease "typical item" in quality after sell-in is below zero
                if (item.SellIn < 0 )
                {
                    // Concert quality goes to 0 after sell in is below (when concert has passed)
                    if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        item.Quality = 0;
                    }
                    //  Brie and Sulfuras increases in quality with time
                    else if (item.Name == "Aged Brie" || item.Name == "Sulfuras, Hand of Ragnaros" && item.Quality < 50)
                    {
                        item.Quality += 1;
                    }
                    // Typical item decreases in quality -1
                    else item.Quality -= itemQualityDegradeAmount;
                }
            }
        }
    }
}
