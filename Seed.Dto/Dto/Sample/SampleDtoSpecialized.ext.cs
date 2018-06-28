using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Seed.Dto
{
	public class SampleDtoSpecialized : SampleDto
	{

        public  SampleTypeDto SampleType { get; set;}

        public IEnumerable<SampleTagDto> CollectionSampleTag { get; set; }

        public IEnumerable<ManySampleTypeDto> CollectionManySampleType { get; set; }


    }
}