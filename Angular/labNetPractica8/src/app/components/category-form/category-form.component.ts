import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';

import { CategoryService } from 'src/app/services/category.service';
import { CategoryModel } from 'src/app/models/category.model';

@Component({
  selector: 'app-category-form',
  templateUrl: './category-form.component.html',
  styleUrls: ['./category-form.component.css'],
})
export class CategoryFormComponent implements OnInit {
  categoryForm: FormGroup;
  category: CategoryModel[] = [];
  error: string = '';

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private categoryService: CategoryService
  ) {
    this.categoryForm = this.formBuilder.group({
      categoryName: ['', [Validators.required, Validators.minLength(3)]],
      description: ['', [Validators.required, Validators.minLength(5)]],
    });
  }

  ngOnInit() {
    const categoryId = +this.route.snapshot.paramMap.get('id') ?? 0;

    if (categoryId) {
      this.categoryService.getCategory(categoryId).subscribe(
        (category: CategoryModel) => {
          this.category = category;
          this.createForm();
        },
        (error: any) => {
          console.log(error);
        }
      );
    } else {
      this.createForm();
    }
  }

  createForm() {
    this.categoryForm = this.formBuilder.group({
      categoryName: [
        this.category ? this.category.categoryName : '',
        Validators.required,
      ],
      description: [
        this.category ? this.category.description : '',
        Validators.required,
      ],
    });
  }

  saveCategory() {
    if (this.categoryForm.valid) {
      const category = { ...this.category, ...this.categoryForm.value };
      if (category.categoryID) {
        this.categoryService.updateCategory(category).subscribe(
          () => {
            this.router.navigate(['/categories']);
          },
          (error: any) => {
            console.log(error);
            this.error = 'An error occurred while saving the category.';
          }
        );
      } else {
        this.categoryService.addCategory(category).subscribe(
          () => {
            this.router.navigate(['/categories']);
          },
          (error: any) => {
            console.log(error);
            this.error = 'An error occurred while saving the category.';
          }
        );
      }
    }
  }
}
