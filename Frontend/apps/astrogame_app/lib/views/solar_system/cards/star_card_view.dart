import 'package:astrogame_app/models/stellar/stellar_objects/star.dart';
import 'package:astrogame_app/views/solar_system/cards/star_card_viewmodel.dart';
import 'package:flutter/material.dart';
import 'package:flutter_svg/svg.dart';
import 'package:stacked/stacked.dart';

class StarCardView extends StatelessWidget {
  final Star _star;

  StarCardView(this._star);

  @override
  Widget build(BuildContext context) {
    return ViewModelBuilder<StarCardViewModel>.reactive(
      builder: (context, model, _) => Container(
        height: 70,
        width: 300,
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
            Text('Planet name'),
            SizedBox(width: 16),
            Text('Any other info')
          ],
        ),
      ),
      viewModelBuilder: () => StarCardViewModel(_star),
    );
  }
}
