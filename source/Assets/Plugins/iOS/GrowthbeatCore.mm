//
//  GrowthbeatCore.mm
//
//
//  Created by Baekwoo Chung on 02/10/15.
//
//

#import <UIKit/UIKit.h>
#import <GrowthbeatCore/GrowthbeatCore.h>

NSString* NSStringFromCharString(const char* charString) {
	if(charString == NULL)
		return nil;
    return [NSString stringWithCString:charString encoding:NSUTF8StringEncoding];
}

extern "C" void initializeWithApplicationId(const char* applicationId, const char* credentialId) {
    [[GrowthbeatCore sharedInstance] initializeWithApplicationId:NSStringFromCharString(applicationId) credentialId:NSStringFromCharString(credentialId)];
}
