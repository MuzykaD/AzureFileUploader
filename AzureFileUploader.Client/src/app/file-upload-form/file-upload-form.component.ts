import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-file-upload-form',
  templateUrl: './file-upload-form.component.html',
  styleUrls: ['./file-upload-form.component.scss']
})
export class FileUploadFormComponent {
  formData: { email: string } = { email: '' };
  selectedFile: File | null = null;
  errorMessage = '';
  constructor(private http: HttpClient, private modalService: NgbModal) {} 

  onSubmit() {
    if (this.selectedFile) {
      const formData = new FormData();
      
      formData.append('email', this.formData.email);
      formData.append('file', this.selectedFile);

      // Send a POST request to your backend API
      // Replace 'your-api-endpoint' with the actual API endpoint URL
       this.http.post('https://azurefileuploader20230917230046.azurewebsites.net/api/v1/upload-file', formData)
         .subscribe(
           response => {
             // Handle a successful response from the backend.
             console.log('Upload success:', response);
             this.modalService.open('File is uploaded! You will get access link via email in 5 minutes!', { centered: true, size: 'm', animation:true });
           },
           error => {
             // Handle an error response from the backend.
             if(error.status === 500){

             this.modalService.open("It seems that the file with such name is already created, modify filename and try again!", {centered: true, size: 'm',animation:true });
            }
             console.error('Upload error:', error);
           }
         );
    }
  }

  onFileChange(event: any) {
    const fileList: FileList = event.target.files;
    if (fileList.length > 0) {
      this.selectedFile = fileList[0];
    }
  }
  isUploadButtonDisabled(): boolean {
    return this.formData.email === '' || !this.validateEmail(this.formData.email) || !this.selectedFile || !this.selectedFile.name.endsWith('.docx');
  }

  isFormValid(): boolean {
    // Check if email is empty or not a valid email
    if (!this.formData.email || !this.validateEmail(this.formData.email)) {
      this.errorMessage = 'Uploading is impossible, wrong email format';
      return false;
    }

    // Check if a file is not selected or it doesn't have a .docx extension
    if (!this.selectedFile || !this.selectedFile.name.endsWith('.docx')) {
      this.errorMessage = 'Uploading is impossible, wrong file extension';
      return false;
    }

    // Clear error message if the form is valid
    this.errorMessage = '';
    return true;
  }

  validateEmail(email: string): boolean {
    // Add your email validation logic here, for example:
    // This is a simple example, you can replace it with a more robust validation
    const emailPattern = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;
    return emailPattern.test(email);
  }
}
