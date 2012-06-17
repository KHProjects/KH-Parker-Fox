using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcAsyncAwaitTest.ViewModels
{
  //ViewModelClass
  [MetadataType(typeof(CourseViewModel_Validation))]
  public class CourseViewModel
  {
    public int CourseID { get; set; }
    public string Title { get; set; }
    public int Credits { get; set; }
  }

  //Validation (Data Annotations)
  public class CourseViewModel_Validation
  {
    [StringLength(50, ErrorMessage = "Title may not be longer then 50 characters")]
    public string Title { get; set; }
  }

}