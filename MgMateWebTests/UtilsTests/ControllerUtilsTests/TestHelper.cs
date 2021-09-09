using System;
using MgMateWeb.Dto;
using MgMateWeb.Models.EntryModels;

namespace MgMateWebTests.UtilsTests.ControllerUtilsTests
{
    public static class TestHelper
    {

        public static AccompanyingSymptom CreateFakeAccompanyingSymptomObject()
        {
            var fakeAccompanyingSymptomObject = new AccompanyingSymptom
            {
                CreationDate = new DateTime(2021, 8, 21),
                Description = "DummyDescription",
                Id = 1
            };
            return fakeAccompanyingSymptomObject;
        }

        public static AccompanyingSymptomDto CreateFakeAccompanyingSymptomDto()
        {
            var fakeDto = new AccompanyingSymptomDto
            {
                CreationDate = new DateTime(2021, 8, 21),
                Description = "DummyDescription",
                Id = 1
            };
            return fakeDto;
        }


    }
}