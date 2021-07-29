import 'package:astrogame_app/themes/astrogame_colors.dart';
import 'package:flutter/material.dart';
import 'package:shimmer_animation/shimmer_animation.dart';

class TechnologyCardPlaceholderView extends StatelessWidget {
  TechnologyCardPlaceholderView();

  @override
  Widget build(BuildContext context) {
    return Container(
      margin: EdgeInsets.only(bottom: 16),
      height: 150,
      decoration: BoxDecoration(
        borderRadius: BorderRadius.circular(16),
        color: AstroGameColors.lightGrey,
      ),
      child: Row(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          // Image
          _imageWidget(),

          Expanded(
            child: Padding(
              padding: const EdgeInsets.all(16.0),
              child: Column(
                mainAxisSize: MainAxisSize.min,
                mainAxisAlignment: MainAxisAlignment.start,
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Row(
                    mainAxisAlignment: MainAxisAlignment.spaceBetween,
                    children: [
                      // Name
                      Shimmer(
                        child: Container(
                          height: 20,
                          width: 100,
                        ),
                        color: Colors.white,
                      ),

                      // Level
                      Shimmer(
                        child: Container(
                          height: 20,
                          width: 100,
                        ),
                        color: Colors.white,
                      ),
                    ],
                  ),

                  // Description
                  Shimmer(
                    child: Container(
                      height: 20,
                      width: 100,
                    ),
                    color: Colors.white,
                  ),
                  Expanded(child: Container()),
                  Row(
                    mainAxisAlignment: MainAxisAlignment.spaceBetween,
                    children: [
                      // Button Details
                      Shimmer(
                        child: Container(
                          height: 20,
                          width: 100,
                        ),
                        color: Colors.white,
                      ),

                      // Button Build
                      Shimmer(
                        child: Container(
                          height: 20,
                          width: 100,
                        ),
                        color: Colors.white,
                      ),
                    ],
                  )
                ],
              ),
            ),
          ),
        ],
      ),
    );
  }

  Widget _imageWidget() {
    return ClipRRect(
      borderRadius: BorderRadius.only(
        topLeft: Radius.circular(16),
        bottomLeft: Radius.circular(16),
        bottomRight: Radius.circular(32),
      ),
      child: Shimmer(
        child: Container(
          height: 150,
          width: 266,
        ),
        color: Colors.white,
      ),
    );
  }
}
