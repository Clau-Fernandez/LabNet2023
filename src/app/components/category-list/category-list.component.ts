import { Component, OnInit } from '@angular/core';
import { CategoryService } from 'src/app/services/category.service';
import { CategoryModel } from 'src/app/models/category.model';
import { ActivatedRoute, Router } from '@angular/router';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css'],
})
export class CategoryListComponent implements OnInit {
  categories: CategoryModel[] = [];
  errorMessage: string = '';
  successMessage: string = '';

  constructor(
    private categoryService: CategoryService,
    private router: Router,
    private activatedRoute: ActivatedRoute
  ) {}

  ngOnInit() {
    this.categoryService.getCategories().subscribe(
      (categories) => {
        this.categories = categories;
      },
      (error) => {
        this.errorMessage = 'Error al obtener las categorías: ' + error.message;
      }
    );
  }

  deleteCategory(categoryId: number) {
    if (confirm('¿Estás seguro que quieres eliminar esta categoría?')) {
      this.categoryService.deleteCategory(categoryId).subscribe(
        () => {
          this.categories = this.categories.filter(
            (category) => category.categoryID !== categoryId
          );
          this.successMessage = 'La categoría ha sido eliminada exitosamente';
        },
        (error) => {
          this.errorMessage =
            'Error al eliminar la categoría: ' + error.message;
        }
      );
    }
  }

  createCategory(category: CategoryModel) {
    this.categoryService.addCategory(category).subscribe(
      (newCategory) => {
        this.categories.push(newCategory);
        this.successMessage = 'La categoría se ha creado con éxito';
      },
      (error) => {
        this.errorMessage = 'Error al crear la categoría: ' + error.message;
      }
    );
  }

  updateCategory(category: CategoryModel) {
    this.categoryService.updateCategory(category).subscribe(
      () => {
        const index = this.categories.findIndex(
          (c) => c.categoryID === category.categoryID
        );
        this.categories[index] = category;
        this.successMessage = 'La categoría se actualizó correctamente';
      },
      (error) => {
        this.errorMessage =
          'Error al actualizar la categoría: ' + error.message;
      }
    );
  }

  addCategory() {
    this.router.navigate(['/categories/add']);
  }

  onSubmit(form: NgForm) {
    if (form.invalid) {
      return;
    }

    const id = this.activatedRoute.snapshot.paramMap.get('id');
    if (!id) {
      this.errorMessage = 'ID de categoría no encontrado';
      return;
    }

    const updatedCategory: CategoryModel = {
      categoryID: parseInt(id),
      categoryName: form.value.categoryName,
      description: form.value.description,
    };

    this.updateCategory(updatedCategory);
    this.router.navigate(['/categories']);
  }
}
