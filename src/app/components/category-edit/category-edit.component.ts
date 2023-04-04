import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CategoryModel } from 'src/app/models/category.model';
import { CategoryService } from 'src/app/services/category.service';

@Component({
  selector: 'app-category-edit',
  templateUrl: './category-edit.component.html',
  styleUrls: ['./category-edit.component.css'],
})
export class CategoryEditComponent implements OnInit {
  categoryForm: FormGroup;
  category: CategoryModel;
  error: boolean = false;
  errorMessage: string = '';

  constructor(
    private fb: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private categoryService: CategoryService,
    private router: Router
  ) {
    this.category = { categoryID: 0, categoryName: '', description: '' };
    this.categoryForm = this.fb.group({
      categoryName: [
        '',
        [
          Validators.required,
          Validators.maxLength(25),
          Validators.pattern(/^[a-zA-Z\s]+(\/[a-zA-Z\s]+)*$/),
        ],
      ],
      description: [
        '',
        [Validators.maxLength(80), Validators.pattern(/^[a-zA-Z,\s]+$/)],
      ],
    });
  }

  ngOnInit(): void {
    this.createCategoryForm();
    const categoryId = +this.activatedRoute.snapshot.paramMap.get('id')!;
    this.categoryService.getCategoryById(categoryId).subscribe(
      (category: CategoryModel) => {
        this.category = category;
        this.populateCategoryForm();
      },
      (error) => {
        console.error(error);
        this.error = true;
        this.errorMessage = 'Se ha producido un error';
      }
    );
  }

  createCategoryForm() {
    this.categoryForm = this.fb.group({
      categoryName: [
        '',
        [
          Validators.required,
          Validators.maxLength(25),
          Validators.pattern(/^[a-zA-Z\s]+(\/[a-zA-Z\s]+)*$/),
        ],
      ],
      description: [
        '',
        [Validators.maxLength(80), Validators.pattern(/^[a-zA-Z,\s]+$/)],
      ],
    });
  }

  populateCategoryForm() {
    this.categoryForm.setValue({
      categoryName: this.category.categoryName,
      description: this.category.description,
    });
  }

  get categoryName() {
    return this.categoryForm.get('categoryName');
  }

  get description() {
    return this.categoryForm.get('description');
  }

  onSubmit() {
    const updatedCategory: CategoryModel = {
      categoryID: +this.activatedRoute.snapshot.paramMap.get('id')!,
      categoryName: this.categoryName!.value,
      description: this.description!.value,
    };
    this.categoryService.updateCategory(updatedCategory).subscribe(
      () => {
        this.router.navigate(['/categories']);
      },
      (error) => {
        console.error(error);
        this.error = true;
        this.errorMessage = 'Se ha producido un error al actualizar los datos';
      }
    );
  }

  goBack() {
    this.router.navigate(['/categories']);
  }
}
