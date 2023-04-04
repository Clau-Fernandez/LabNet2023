import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CategoryModel } from 'src/app/models/category.model';
import { CategoryService } from 'src/app/services/category.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-category-add',
  templateUrl: './category-add.component.html',
  styleUrls: ['./category-add.component.css'],
})
export class CategoryAddComponent {
  addForm: FormGroup;
  maxCategoryNameLength = 25;
  maxDescriptionLength = 80;
  categoryNamePattern = /^[a-zA-Z\s]+(\/[a-zA-Z\s]+)*$/;
  descriptionPattern = /^[a-zA-Z,\s]+$/;
  error: string = '';

  constructor(
    private categoryService: CategoryService,
    private formBuilder: FormBuilder,
    private router: Router
  ) {
    this.addForm = this.formBuilder.group({
      categoryName: [
        '',
        [
          Validators.required,
          Validators.pattern(this.categoryNamePattern),
          Validators.maxLength(this.maxCategoryNameLength),
        ],
      ],
      description: [
        '',
        [
          Validators.pattern(this.descriptionPattern),
          Validators.maxLength(this.maxDescriptionLength),
        ],
      ],
    });
  }

  onSubmit() {
    if (this.addForm.invalid) {
      this.error = 'Por favor, corrija los errores del formulario.';
      return;
    }

    const newCategory: CategoryModel = {
      categoryName: this.addForm.value.categoryName,
      description: this.addForm.value.description,
    };

    this.categoryService.addCategory(newCategory).subscribe(
      () => {
        this.addForm.reset();
        this.error = '';
        this.router.navigateByUrl('/categories');
      },
      (error) => {
        this.error = error.message;
      }
    );
  }

  get categoryName() {
    return this.addForm.get('categoryName');
  }

  get description() {
    return this.addForm.get('description');
  }
  resetForm() {
    this.addForm.reset();
    this.router.navigateByUrl('/categories');
  }
}
