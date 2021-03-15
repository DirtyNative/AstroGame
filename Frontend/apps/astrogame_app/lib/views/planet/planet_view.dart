import 'package:astrogame_app/configurations/service_container.dart';
import 'package:astrogame_app/models/stellar/stellar_objects/planet.dart';
import 'package:astrogame_app/views/planet/planet_viewmodel.dart';
import 'package:astrogame_app/widgets/glass_container.dart';
import 'package:expandable/expandable.dart';
import 'package:flutter/material.dart';
import 'package:stacked/stacked.dart';
import 'package:stacked_services/stacked_services.dart';

class PlanetView extends StatelessWidget {
  final Planet _planet;

  PlanetView(this._planet);

  @override
  Widget build(BuildContext context) {
    return ViewModelBuilder<PlanetViewModel>.reactive(
      builder: (context, model, _) => Scaffold(
        body: Container(
          decoration: BoxDecoration(
            image: DecorationImage(
                image: AssetImage('assets/images/background_2.png'),
                fit: BoxFit.cover),
          ),
          /* decoration: BoxDecoration(
            image: DecorationImage(
                image: NetworkImage(model.imageUrl), fit: BoxFit.cover),
          ),*/
          child: Stack(
            children: [
              Center(
                /*child: Image.asset(
                  'assets/images/screen_1.png',
                  width: MediaQuery.of(context).size.height,
                ), */

                child: Image.network(
                  model.imageUrl,
                  height: MediaQuery.of(context).size.height,
                ),
              ),
              SingleChildScrollView(
                child: Padding(
                  padding: const EdgeInsets.symmetric(vertical: 24.0),
                  child: Column(
                    mainAxisAlignment: MainAxisAlignment.start,
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      _headerWidget(context, model),
                      SizedBox(
                        height: MediaQuery.of(context).size.height - 300,
                      ),
                      _detailsView(context),
                      _resourcesView(context),
                    ],
                  ),
                ),
              ),
            ],
          ),
        ),
      ),
      viewModelBuilder: () =>
          new PlanetViewModel(getIt.get<NavigationService>(), _planet),
    );
  }

  Widget _headerWidget(BuildContext context, PlanetViewModel model) {
    return Padding(
      padding: EdgeInsets.only(top: 24),
      child: Column(
        children: [
          Align(
            alignment: Alignment.topLeft,
            child: Padding(
              padding: const EdgeInsets.only(left: 24.0),
              child: InkWell(
                child: Icon(
                  Icons.arrow_back,
                  size: 20,
                ),
                onTap: model.goBack,
              ),
            ),
          ),
          Text(
            'NEPTUNE',
            style: Theme.of(context).textTheme.headline1,
            textAlign: TextAlign.center,
          ),
        ],
      ),
    );
  }

  Widget _detailsView(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.symmetric(horizontal: 24),
      child: GlassContainer(
        child: Column(
          children: [
            Row(
              children: [
                Expanded(
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.center,
                    children: [
                      Text(
                        'Type',
                        style: Theme.of(context).textTheme.headline3,
                      ),
                      Text('Ice Planet'),
                    ],
                  ),
                ),
                Expanded(
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.center,
                    children: [
                      Text(
                        'Axial tilt',
                        style: Theme.of(context).textTheme.headline3,
                      ),
                      Text('-20 0 -20'),
                    ],
                  ),
                ),
              ],
            ),
            SizedBox(height: 16),
            Row(
              children: [
                Expanded(
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.center,
                    children: [
                      Text(
                        'Atmosphere',
                        style: Theme.of(context).textTheme.headline3,
                      ),
                      Text('Yes'),
                    ],
                  ),
                ),
                Expanded(
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.center,
                    children: [
                      Text(
                        'Rings',
                        style: Theme.of(context).textTheme.headline3,
                      ),
                      Text('No'),
                    ],
                  ),
                ),
              ],
            ),
            SizedBox(height: 16),
            Row(
              children: [
                Expanded(
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.center,
                    children: [
                      Text(
                        'Atmosphere',
                        style: Theme.of(context).textTheme.headline3,
                      ),
                      Text('Yes'),
                    ],
                  ),
                ),
                Expanded(
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.center,
                    children: [
                      Text(
                        'Rings',
                        style: Theme.of(context).textTheme.headline3,
                      ),
                      Text('No'),
                    ],
                  ),
                ),
              ],
            ),
          ],
        ),
        borderRadius: BorderRadius.circular(8),
        sigmaX: 5,
        sigmaY: 5,
      ),
    );
  }

  Widget _resourcesView(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.only(left: 24, right: 24, top: 24),
      child: GlassContainer(
        padding: EdgeInsets.all(0),
        child: ExpandablePanel(
          header: Padding(
            padding: const EdgeInsets.only(left: 24.0),
            child: Text(
              'Resources',
              style: Theme.of(context).textTheme.headline3,
            ),
          ),
          expanded: Padding(
            padding: const EdgeInsets.only(
              left: 24,
              right: 24,
              bottom: 16,
            ),
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Text('Helium (He)'),
                Padding(
                  padding: const EdgeInsets.only(top: 2.0),
                  child: Text('Oxygen (O)'),
                ),
                Padding(
                  padding: const EdgeInsets.only(top: 2.0),
                  child: Text('Gold (Au)'),
                ),
              ],
            ),
          ),
          theme: ExpandableThemeData(
            iconColor: Colors.white,
            headerAlignment: ExpandablePanelHeaderAlignment.center,
          ),
        ),
        borderRadius: BorderRadius.circular(8),
        sigmaX: 5,
        sigmaY: 5,
      ),
    );
  }
}
