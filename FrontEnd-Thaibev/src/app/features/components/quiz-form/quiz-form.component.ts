import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { ButtonModule } from 'primeng/button';
import { FormsModule } from '@angular/forms';
import { RadioButtonModule } from 'primeng/radiobutton';
@Component({
  selector: 'app-quiz-form',
  standalone: true,
  imports: [
    CommonModule,
    RadioButtonModule,
    ButtonModule,
    FormsModule],
  templateUrl: './quiz-form.component.html',
  styleUrl: './quiz-form.component.css'
})
export class QuizFormComponent {

  questions = [
    { id: 1, text: 'ข้อใดต่างจากข้ออื่น', choices: ['3', '5', '9', '11'] },
    { id: 2, text: 'X + 2 = 4 จงหาค่า X', choices: ['1', '2', '3', '4'] }
  ];

  constructor(private router: Router) { }

  addQuestion() {
    this.router.navigate(['/add']); // Go to IT 08-2
  }

  deleteQuestion(id: number) {
    // When you remove an item, Angular's index in the HTML 
    // will handle the "Running Number" update automatically
    this.questions = this.questions.filter(q => q.id !== id);
  }

}
