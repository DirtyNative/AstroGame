import 'package:flutter/material.dart';
import 'package:shimmer_animation/shimmer_animation.dart';

class ConstructionPlaceholderView extends StatelessWidget {
  ConstructionPlaceholderView();

  @override
  Widget build(BuildContext context) {
    return Container(
      child: Row(
        mainAxisAlignment: MainAxisAlignment.start,
        children: [
          // Image
          Container(
            height: 100,
            width: 177,
            child: Center(
              child: CircularProgressIndicator(),
            ),
          ),
          Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              // StellarObject name
              Shimmer(
                child: Container(
                  height: 24,
                  width: 100,
                ),
                color: Colors.white,
              ),
            ],
          ),
        ],
      ),
    );
  }
}
