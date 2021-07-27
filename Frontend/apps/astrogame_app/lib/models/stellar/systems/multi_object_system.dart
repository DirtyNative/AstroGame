import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/communications/converters/stellar_object_converter.dart';
import 'package:astrogame_app/communications/converters/stellar_system_converter.dart';
import 'package:astrogame_app/models/common/guid.dart';
import 'package:astrogame_app/models/stellar/base_types/stellar_system.dart';

import 'package:json_annotation/json_annotation.dart';

part 'multi_object_system.g.dart';

@StellarObjectConverter()
@StellarSystemConverter()
@GuidConverter()
@JsonSerializable()
class MultiObjectSystem extends StellarSystem {
  @JsonKey()
  late Guid parentId;

  @JsonKey()
  late StellarSystem parent;

  @JsonKey()
  late int order;

  MultiObjectSystem();

  factory MultiObjectSystem.fromJson(Map<String, dynamic> json) =>
      _$MultiObjectSystemFromJson(json);
  Map<String, dynamic> toJson() => _$MultiObjectSystemToJson(this);
}
