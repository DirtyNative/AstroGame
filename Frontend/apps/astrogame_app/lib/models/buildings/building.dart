import 'package:astrogame_app/communications/converters/building_converter.dart';
import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/models/enums/building_type.dart';
import 'package:astrogame_app/models/enums/stellar_object_type.dart';
import 'package:astrogame_app/models/technologies/technology.dart';
import 'package:json_annotation/json_annotation.dart';

import 'input_resource.dart';
import 'output_resource.dart';

@GuidConverter()
abstract class Building extends Technology {
  @JsonKey()
  late BuildingType buildingType;

  @JsonKey()
  late StellarObjectType buildableOn;

  @JsonKey()
  List<InputResource>? inputResources = [];

  @JsonKey()
  List<OutputResource>? outputResource = [];

  Building();

  factory Building.fromJson(Map<String, dynamic> json) =>
      BuildingConverter().fromJson(json);
}
