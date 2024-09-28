//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.Extensions.Hosting;
//using PizzaStore.Data;
//using PizzaStore.Models;

//namespace PizzaStore.Pages.Products
//{
//    public class CreateModel : PageModel
//    {
//        private readonly PizzaContext _context;
//        private Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment;

//        public CreateModel(PizzaContext context, Microsoft.AspNetCore.Hosting.IHostingEnvironment enviroment )
//        {
//            _context = context;
//            _environment = enviroment;
//        }
//        [Required(ErrorMessage = "Please choose at least one file.")]
//        [DataType(DataType.Upload)]
//        [FileExtensions(Extensions = "png,jpg,jpeg,gif")]
//        [Display(Name = "Choose file(s) to upload")]
//        [BindProperty]
//        public IFormFile[] FileUploads { get; set; }
//        public IActionResult OnGet()
//        {
//            return Page();
//        }

//        [BindProperty]
//        public Models.Products Products { get; set; } = default!;
//        public async Task<IActionResult> OnPostAsync()
//        {
//            if (!ModelState.IsValid)
//            {
//                return Page();
//            }
//            if (FileUploads != null)
//            {
//                foreach (var FileUpload in FileUploads)
//                {
//                    var file = Path.Combine(_environment.ContentRootPath, "Images", FileUpload.FileName);
//                    using (var fileStream = new FileStream(file, FileMode.Create))
//                    {
//                        await FileUpload.CopyToAsync(fileStream);
//                    }
//                }
//            }
//            _context.Products.Add(Products);
//            await _context.SaveChangesAsync();
//            return RedirectToPage("./Index");
//        }
//    }
//}


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;
using PizzaStore.Data;
using PizzaStore.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PizzaStore.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly PizzaContext _context;
        private readonly Microsoft.AspNetCore.Hosting.IWebHostEnvironment _environment; // Sửa thành IWebHostEnvironment

        public CreateModel(PizzaContext context, Microsoft.AspNetCore.Hosting.IWebHostEnvironment environment) // Sửa tên tham số
        {
            _context = context;
            _environment = environment;
        }

        [BindProperty]
        [Required(ErrorMessage = "Please choose at least one file.")]
        [DataType(DataType.Upload)]
        [Display(Name = "Choose file(s) to upload")]
        //[FileExtensions(Extensions = "png,jpg,jpeg,gif")]
        public IFormFile[] FileUploads { get; set; }

        [BindProperty]
        public Models.Products Products { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync()
        {

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}
            var category = _context.Categories.ToList();
            var test = FileUploads;
            if (FileUploads != null && FileUploads.Length > 0)
            {
                string imagesFolder = Path.Combine(_environment.ContentRootPath, "Images");
                Directory.CreateDirectory(imagesFolder);

                foreach (var FileUpload in FileUploads)
                {
                    var filePath = Path.Combine(imagesFolder, FileUpload.FileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await FileUpload.CopyToAsync(fileStream);
                        Products.ProductImage = filePath;
                    }
                }
               
            }
            _context.Products.Add(Products);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
