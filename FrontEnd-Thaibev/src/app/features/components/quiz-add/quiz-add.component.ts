import { Component, inject, OnInit, OnDestroy } from '@angular/core';
import { Button } from "primeng/button";
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { FormsModule } from '@angular/forms';


@Component({
  selector: 'app-quiz-add',
  standalone: true,
  imports: [
    Button,
    ButtonModule,
    InputTextModule,
    FormsModule,
  ],
  templateUrl: './quiz-add.component.html',
  styleUrl: './quiz-add.component.css'
})
export class QuizAddComponent implements OnInit {

  choiceItems: any[] = [];

  constructor() { }

  ngOnInit(): void {
  }

  defineValue() {
    this.choiceItems = [
      { id: 0, reqQuestionId: 0, choiceText: 'ตัวเลือกที่ 1', isCorrect: 'Y', createDate: new Date() },
      { id: 0, reqQuestionId: 0, choiceText: 'ตัวเลือกที่ 2', isCorrect: 'N', createDate: new Date() },
      { id: 0, reqQuestionId: 0, choiceText: 'ตัวเลือกที่ 3', isCorrect: 'N', createDate: new Date() },
      { id: 0, reqQuestionId: 0, choiceText: 'ตัวเลือกที่ 4', isCorrect: 'N', createDate: new Date() }
    ];
  }

  validation() {

  }

  saveData() {

  }

  ngOnDestroy() {
  }

}
