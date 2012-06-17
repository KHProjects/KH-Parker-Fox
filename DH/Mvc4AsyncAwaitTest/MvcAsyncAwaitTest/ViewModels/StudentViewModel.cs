using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcAsyncAwaitTest.ViewModels
{
  //ViewModelClass
  [MetadataType(typeof(StudentViewModel_Validation))]
  public class StudentViewModel
  {
    public int StudentID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
  }
 
  //Validation (Data Annotations)
  public class StudentViewModel_Validation
  {
    [StringLength(50, ErrorMessage = "FirstName may not be longer then 50 characters")]
    public string FirstName { get; set; }
  }

}