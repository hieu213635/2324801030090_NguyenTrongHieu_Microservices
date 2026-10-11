using System;
using System.Collections.Generic;
namespace ProductService.Api.Queries.Dtos;
public class ChoiceDto { public string Code { get; set; } public string Label { get; set; } }
public class CoverDto { public string Code { get; set; } public string Name { get; set; } public string Description { get; set; } public bool Optional { get; set; } public decimal SumInsured { get; set; } }
public class QuestionDto { public string QuestionCode { get; set; } public string Text { get; set; } }
public class ChoiceQuestionDto : QuestionDto { public List<ChoiceDto> Choices { get; set; } = new(); }
public class NumericQuestionDto : QuestionDto { }
public class ProductDto
{
    public string Code { get; set; }
    public string Name { get; set; }
    public string Image { get; set; }
    public string Description { get; set; }
    public int MaxNumberOfInsured { get; set; }
    public List<CoverDto> Covers { get; set; } = new();
    public List<QuestionDto> Questions { get; set; } = new();
}
