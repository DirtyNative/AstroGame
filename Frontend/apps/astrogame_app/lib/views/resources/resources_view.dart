import 'package:astrogame_app/configurations/service_locator.dart';
import 'package:astrogame_app/models/resources/resource.dart';
import 'package:astrogame_app/models/resources/element.dart' as resources;
import 'package:astrogame_app/themes/astrogame_colors.dart';
import 'package:astrogame_app/views/resources/resources_viewmodel.dart';
import 'package:astrogame_app/widgets/scaffold_base.dart';
import 'package:flutter/material.dart';
import 'package:google_nav_bar/google_nav_bar.dart';
import 'package:stacked/stacked.dart';

class ResourcesView extends StatelessWidget {
  final PageController controller = PageController();

  @override
  Widget build(BuildContext context) {
    return ViewModelBuilder<ResourcesViewModel>.reactive(
      builder: (context, model, _) => ScaffoldBase(
        body: Container(
          child: Column(
            children: [
              Padding(
                padding: const EdgeInsets.only(left: 32, right: 32, top: 32),
                child: _tabWidget(model),
              ),
              Divider(color: Colors.white),
              Expanded(
                child: PageView(
                  controller: controller,
                  onPageChanged: (index) => model.selectedTabIndex = index,
                  children: [
                    _listView(context, model.elements),
                    _listView(context, model.buildingMaterials),
                    _listView(context, model.consumableMaterials),
                    _listView(context, model.componentMaterials),
                    _listView(context, model.alloyMaterials),
                    _listView(context, model.fuelMaterials),
                  ],
                ),
              ),
            ],
          ),
        ),
      ),
      viewModelBuilder: () => ServiceLocator.get(),
    );
  }

  Widget _tabWidget(ResourcesViewModel model) {
    return Container(
      child: GNav(
        selectedIndex: model.selectedTabIndex,
        padding: EdgeInsets.all(10),
        gap: 8,
        iconSize: 24,
        color: Colors.white,
        tabBackgroundGradient: LinearGradient(colors: [
          AstroGameColors.purple,
          AstroGameColors.torque,
        ]),
        activeColor: Colors.white,
        textStyle: TextStyle(color: Colors.white),
        tabs: [
          GButton(
            icon: Icons.science_outlined,
            text: 'Elements',
          ),
          GButton(
            icon: Icons.home,
            text: 'Building',
          ),
          GButton(
            icon: Icons.fastfood,
            text: 'Consumables',
          ),
          GButton(
            icon: Icons.fastfood,
            text: 'Components',
          ),
          GButton(
            icon: Icons.fastfood,
            text: 'Alloys',
          ),
          GButton(
            icon: Icons.local_gas_station,
            text: 'Fuels',
          ),
        ],
        onTabChange: (index) {
          model.selectedTabIndex = index;
          controller.jumpToPage(index);
        },
      ),
    );
  }

  Widget _listView(BuildContext context, List<Resource> resourceList) {
    return Padding(
      padding: const EdgeInsets.only(left: 32, right: 32, bottom: 32),
      child: ListView.separated(
          itemBuilder: (context, index) {
            if (resourceList[index] is resources.Element) {
              return _elementWidget(context, resourceList[index]);
            }

            return Container(
              height: 50,
              decoration: BoxDecoration(
                borderRadius: BorderRadius.circular(16),
                color: AstroGameColors.lightGrey,
              ),
            );
          },
          separatorBuilder: (context, index) => SizedBox(height: 16),
          itemCount: resourceList.length ?? 0),
    );
  }

  Widget _elementWidget(BuildContext context, resources.Element element) {
    return Container(
      decoration: BoxDecoration(
        borderRadius: BorderRadius.circular(16),
        color: AstroGameColors.lightGrey,
      ),
      child: Row(
        children: [
          Padding(
            padding: const EdgeInsets.all(8.0),
            child: _elementIconWidget(context, element),
          )
        ],
      ),
    );
  }

  Widget _elementIconWidget(BuildContext context, resources.Element element) {
    return Container(
      height: 80,
      width: 80,
      decoration: BoxDecoration(
          color: AstroGameColors.mediumGrey,
          borderRadius: BorderRadius.circular(8),
          border: Border.all(color: Colors.white, width: 3)),
      child: Stack(
        children: [
          Positioned(
            top: 10,
            left: 0,
            right: 0,
            child: Center(
              child: Text(
                element.symbol,
                textAlign: TextAlign.center,
                style: Theme.of(context).textTheme.headline2,
              ),
            ),
          ),
          Positioned(
            bottom: 4,
            left: 0,
            right: 0,
            child: Center(child: Text(element.name)),
          )
        ],
      ),
    );
  }
}
