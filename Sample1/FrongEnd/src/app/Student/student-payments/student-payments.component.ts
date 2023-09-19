import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DataShare } from 'src/app/Services/SharedDataObS.service';
import { DataService } from 'src/app/Services/data.service';
import CommonApiService from 'src/app/Urls/CommonApiServices';
import { ConstansUrlService } from 'src/app/Urls/ConstansUrlService';

@Component({
  selector: 'app-student-payments',
  templateUrl: './student-payments.component.html',
  styleUrls: ['./student-payments.component.scss']
})
export class StudentPaymentsComponent {
  groupNames: { [key: number]: string } = {
    1: 'MPC',
    2: 'PIBC',
    3: 'CEC',
    4: 'MEC',
    5: 'MPC',
    6: 'BIPC'
  };
  studentPaymentdDetails: any;
  student: any;
  transactions: any[] = [];
  notransaction: boolean = false;
  totalAmount: any;
  totalAmountPaid = 0;
  balanceAmount = 0;
  anyMoneybtn: boolean = true;
  amtRecvBy: any;
  paidAmount: any;
  remainingAmt: any;
  textmsg: string = '';
  myForm!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private studentDataService: DataShare,
    private apiService: CommonApiService,
  ) { }
  ngOnInit() {
    this.myForm = this.fb.group({
      paidAmount: [null, [Validators.required, Validators.pattern(/^\d+$/)]],
    });
    this.getStudentData();
  }
  getStudentData() {
    this.studentDataService.studentData$.subscribe((student) => {
      this.student = student;
      if (this.student) {
        if (this.student.groupId == 1) {
          this.totalAmount = 10000
        }
        else if (this.student.groupId == 2) {
          this.totalAmount = 11000
        }
        else if (this.student.groupId == 3) {
          this.totalAmount = 12000
        }
        else if (this.student.groupId == 4) {
          this.totalAmount = 11000
        }
        else if (this.student.groupId == 5) {
          this.totalAmount = 15000
        }
        else if (this.student.groupId == 6) {
          this.totalAmount = 7000
        }
      }
      this.paymestHistory();
    });
  }
  paymestHistory() {
    const { GetStuPaymentbyid } = ConstansUrlService;
    const updateUrl = `${GetStuPaymentbyid}${this.student.id.toString()}`;
    this.apiService.getData(updateUrl).subscribe(res => {
      if (Array.isArray(res)) {
        if (res.length === 0) {
          this.notransaction = true
        } else {
          this.notransaction = false
          this.studentPaymentdDetails = res;
          this.transactions = this.studentPaymentdDetails[0].transactions;
          this.transactions.forEach(transaction => {
            if (transaction.paidAmount) {
              this.totalAmountPaid += transaction.paidAmount;
              this.balanceAmount = this.totalAmount - this.totalAmountPaid
              if (this.balanceAmount <= 0) {
                this.anyMoneybtn = false;
              }
            }
          });
        }
      }
    })
  }
  calculateRemainingAmount() {
    const paidAmount = this.myForm.get('paidAmount')?.value;
    if (this.balanceAmount > 0) {
      this.remainingAmt = this.balanceAmount - paidAmount;
      if (this.remainingAmt <= 0) {
        this.textmsg = "Your are Entering More than actual Amount"
      }
    }
    else{
      this.remainingAmt = this.totalAmount - paidAmount;
      if (this.remainingAmt <= 0) {
        this.textmsg = "Your are Entering More than actual Amount"
      }
    }
  }
  submitPayment() {
    debugger;
    const paymentDetails = {
      studentId: this.student.id,
      TotalAmount: this.totalAmount,
      PaidAmount: this.myForm.get('paidAmount')?.value,
      amountReceivedBy: this.amtRecvBy,
      PadiDate: Date.now
    }

    const { PostStuPayment } = ConstansUrlService;
    const updateUrl = `${PostStuPayment}`;
    this.apiService.postData(updateUrl, paymentDetails).subscribe(res => {
      console.log(res);
    })
  }
}
