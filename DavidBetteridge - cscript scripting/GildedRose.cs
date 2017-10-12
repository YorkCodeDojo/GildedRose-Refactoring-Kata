using csharp.Rules;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        private Dictionary<string, Script<int>> snippets = new Dictionary<string, Script<int>>();
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
            LoadCodeSnippets();
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                UpdateItem(Items[i]);
            }
        }

        private void UpdateItem(Item item)
        {
            var previousSellin = item.SellIn;

            DTO dtoFromItem() => new DTO()
            {
                PreviousSellin = previousSellin,
                Name = item.Name,
                Quality = item.Quality,
                SellIn = item.SellIn
            };

            // Sellin
            snippets.TryGetValue("Sellin." + GetSellInCodeSnippetName(item), out var script);
            var result = script.RunAsync(dtoFromItem()).Result.ReturnValue;
            item.SellIn = result;

            // Qualtity
            snippets.TryGetValue("Quality." + GetQualityCodeSnippetName(item), out var qualityScript);
            result = qualityScript.RunAsync(dtoFromItem()).Result.ReturnValue;
            item.Quality = result;

            item.Quality = Math.Max(0, item.Quality);
        }



        private static string GetSellInCodeSnippetName(Item item)
        {
            switch (item.Name)
            {
                case "Sulfuras, Hand of Ragnaros":
                    return "Static";

                default:
                    return "Normal";
            }
        }

        private static string GetQualityCodeSnippetName(Item item)
        {
            switch (item.Name)
            {
                case "Aged Brie":
                    return "Increasing";

                case "Sulfuras, Hand of Ragnaros":
                    return "Static";

                case "Backstage passes to a TAFKAL80ETC concert":
                    return "Urgent";

                case "Conjured Mana Cake":
                    return "FastDegrade";

                default:
                    return "Normal";
            }
        }

        private void LoadCodeSnippets()
        {
            string GetSellInCode(string ruleName, string snippetName)
            {
                var resourceName = $@"csharp.Rules.{ruleName}.{snippetName}.csx";
                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }

            void LoadCodeSnippet(string rule, string name)
            {
                var code = GetSellInCode(rule, name);
                var script = CSharpScript.Create<int>(code, globalsType: typeof(DTO));
                script.Compile();
                this.snippets.Add($"{rule}.{name}", script);
            }

            LoadCodeSnippet("Sellin", "Normal");
            LoadCodeSnippet("Sellin", "Static");

            LoadCodeSnippet("Quality", "Increasing");
            LoadCodeSnippet("Quality", "Static");
            LoadCodeSnippet("Quality", "Urgent");
            LoadCodeSnippet("Quality", "FastDegrade");
            LoadCodeSnippet("Quality", "Normal");
        }
    }
}
