using System.Collections.Generic;
using Packt.Shared;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
public class Result
{
    public string poster_path { get; set; }
    public string overview{get;set;}
    
}

public class original
{
    public List<Result> results { get; set; }
    
}