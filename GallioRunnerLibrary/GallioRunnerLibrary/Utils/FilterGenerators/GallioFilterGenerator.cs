using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GallioRunnerLibrary.Utils.FilterGenerators
{
    public class GallioFilterGenerator
    {
        public const string FilterUrl = "http://www.gallio.org/wiki/doku.php?id=tools:gallio_test_selection_filters";

        public string GenerateFixtureFilter(string fixtureName)
        {
            return FilterAllFixtureTests(fixtureName);
        }

        public string GenerateSpecificTestsFilter(List<string> lists)
        {
            return new SpecificTestsGenerator().AddTests(lists).Filter;
        }

        private string FilterAllFixtureTests(string fixtureName)
        {
            return new FixtureFilterGenerator().AddFixture(fixtureName).Filter;
        }
    }
}
