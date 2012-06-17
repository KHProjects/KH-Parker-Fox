using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcAsyncAwaitTest.ViewModels
{
  //ViewModelClass
  [MetadataType(typeof(EnrolmentViewModel_Validation))]
  public class EnrolmentViewModel
  {
    public int EnrolmentID { get; set; }
    public int StudentID { get; set; }
    public int CourseID { get; set; }
    public DateTime EnrolmentDate { get; set; }
    public decimal? Grade { get; set; }
  }

  //Validation (Data Annotations)
  public class EnrolmentViewModel_Validation
  {
    [Required(ErrorMessage = "EnrolmentDate is required")]
    public DateTime EnrolmentDate { get; set; }
  }

}