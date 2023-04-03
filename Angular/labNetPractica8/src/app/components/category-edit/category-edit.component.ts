import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CategoryModel } from 'src/app/models/category.model';
import { CategoryService } from 'src/app/services/category.service';

@Component({
  selector: 'app-category-edit',
  templateUrl: './category-edit.component.html',
  styleUrls: ['./category-edit.component.css'],
})
export class CategoryEditComponent implements OnInit {
  category: CategoryModel = {
    categoryID: 0,
    categoryName: '',
    description: '',
  };
  isNewCategory = true;

  constructor(
    private categoryService: CategoryService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    const categoryId = +this.route.snapshot.paramMap.get('id') || 0;

    if (categoryId) {
      this.isNewCategory = false;
      this.categoryService.getCategoryById(categoryId).subscribe(
        (category) => {
          this.category = category;
        },
        (error) => {
          console.log(error);
        }
      );
    }
  }

  onSubmit(): void {
    if (this.isNewCategory) {
      this.categoryService.createCategory(this.category).subscribe(
        () => {
          this.router.navigate(['/categories']);
        },
        (error) => {
          console.log(error);
        }
      );
    } else {
      this.categoryService.updateCategory(this.category).subscribe(
        () => {
          this.router.navigate(['/categories']);
        },
        (error) => {
          console.log(error);
        }
      );
    }
  }

  onCancel(): void {
    this.router.navigate(['/categories']);
  }
}
