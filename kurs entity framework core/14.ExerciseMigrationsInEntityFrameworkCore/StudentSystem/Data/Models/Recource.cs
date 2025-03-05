using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Data.Models
{
	public class Recource
	{
		[Key]
		public int RecourceId { get; set; }

		[MaxLength(50)]
		public string Name { get; set; }
        public string Url { get; set; }
        public RecourceType RecourceType { get; set; }

		[ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
		public Course Course { get; set; }
    }
}
