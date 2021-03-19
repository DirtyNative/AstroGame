import 'package:astrogame_app/models/stellar/stellar_objects/star.dart';
import 'package:flutter/material.dart';
import 'package:flutter_svg/svg.dart';

class StarCardView extends StatelessWidget {
  final Star _star;

  StarCardView(this._star);

  @override
  Widget build(BuildContext context) {
    return Container(
      height: 70,
      child: Row(
        children: [
          SvgPicture.asset(
            'assets/images/star.svg',
            color: Colors.white,
            semanticsLabel: 'A red up arrow',
            height: 50,
          ),
          /*ImageIcon(
              AssetImage('assets/images/star.png'),
              size: 50,
            ),*/
          SizedBox(width: 16),
          Text('${_star.name}'),
          SizedBox(width: 16),
          Text(_star.coordinates.toString()),
        ],
      ),
    );
  }
}
