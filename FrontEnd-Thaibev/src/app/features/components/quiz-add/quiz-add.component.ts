import { Component, inject, OnInit, OnDestroy } from '@angular/core';
import { FormsModule } from '@angular/forms';

// import primeNG
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';
import { Button } from "primeng/button";
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';


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
  styleUrl: './quiz-add.component.css',
  providers: [DialogService, DynamicDialogRef]
})
export class QuizAddComponent implements OnInit {
  public ref = inject(DynamicDialogRef);
  public dialogService = inject(DialogService);

  choiceItems: any[] = [];

  constructor() { }

  ngOnInit(): void {
    this.defineValue();
  }

  defineValue() {
    this.choiceItems = [
      { id: 0, reqQuestionId: 0, choiceText: 'ตัวเลือกที่ 1', isCorrect: 'Y', createDate: new Date() },
      { id: 0, reqQuestionId: 0, choiceText: 'ตัวเลือกที่ 2', isCorrect: 'N', createDate: new Date() },
      { id: 0, reqQuestionId: 0, choiceText: 'ตัวเลือกที่ 3', isCorrect: 'N', createDate: new Date() },
      { id: 0, reqQuestionId: 0, choiceText: 'ตัวเลือกที่ 4', isCorrect: 'N', createDate: new Date() }
    ];
  }


  async saveData() {
    const valiData = await this.validation();
    console.log('validateData: ', valiData);
  }

  cancel(){
    this.ref?.close();
    console.log('cancel',this.ref);
  }

  async validation() {
    const validateData = this.choiceItems.every(item => item.choiceText && item.choiceText.trim() !== '');
    return validateData;
  }

  ngOnDestroy() {
  }

}
