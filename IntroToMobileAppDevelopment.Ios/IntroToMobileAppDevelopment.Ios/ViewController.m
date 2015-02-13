//
//  ViewController.m
//  IntroToMobileAppDevelopment.Ios
//
//  Created by Brad Linard on 2/8/15.
//  Copyright (c) 2015 Example. All rights reserved.
//

#import "ViewController.h"
#import <UNIRest.h>

@interface ViewController ()

@end

@implementation ViewController

@synthesize btnGetANumber;
@synthesize lblNumber;


- (void)viewDidLoad {
    [super viewDidLoad];
    
    [btnGetANumber addTarget:self action:@selector(btnGetANumber_onTouchUpInside:) forControlEvents:UIControlEventTouchUpInside];
    
}

- (void)btnGetANumber_onTouchUpInside:(id)sender {
    NSDictionary *headers = @{@"accept": @"application/json"};
    
    [[UNIRest get:^(UNISimpleRequest *request) {
        [request setUrl:@"http://introtomobileappdevelopment.azurewebsites.net/api/RandomNumber"];
        [request setHeaders:headers];
    }] asStringAsync:^(UNIHTTPStringResponse *stringResponse, NSError *error) {
        NSString *result = stringResponse.body;
        [self performSelectorOnMainThread:@selector(updateLabel:) withObject:[NSString stringWithFormat: @"Your number is\n%@",result] waitUntilDone:true];
    }];
    
}

- (void)updateLabel:(NSString*) value {
    [lblNumber setText:value];
    
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

@end
