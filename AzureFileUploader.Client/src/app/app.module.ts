import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms'; // Import FormsModule
import { HttpClientModule } from '@angular/common/http'; // Import HttpClientModule

import { AppComponent } from './app.component';
import { FileUploadFormComponent } from './file-upload-form/file-upload-form.component';

@NgModule({
  declarations: [AppComponent, FileUploadFormComponent],
  imports: [BrowserModule, FormsModule, HttpClientModule], // Add FormsModule and HttpClientModule to imports
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
